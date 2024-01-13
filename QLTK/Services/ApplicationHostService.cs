using DiscordRPC;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using QLTK.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace QLTK.Services;
public class ApplicationHostService : IHostedService
{
    private const string GameAssemblyPath = @"Game_Data\Managed\Assembly-CSharp.dll";
    private const string QLTKPath = @"QLTK.dll";

    private MainService _mainService;
    private SaveSettings _saveSettings;
    private AsynchronousSocketListener _socketListener;
    private AppConfig _appConfig;

    private bool _isInitialized;

    private DiscordRpcClient discordClient;

    private Timestamps timestampsStartQLTK = new Timestamps(DateTime.UtcNow);

    private bool isDiscordRichPresenceDisabled;

    private Mutex mutex = new Mutex(true, "{b2dbc8db-7340-4a4a-8e63-f9ec86e5a4fd}");

    private DevelopStatus currentDevelopStatus;


    public ApplicationHostService(MainService mainService, SaveSettings saveSettings, AsynchronousSocketListener socketListener, IOptions<AppConfig> config)
    {
        _mainService = mainService;
        _saveSettings = saveSettings;
        _socketListener = socketListener;
        _appConfig = config.Value;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        new Thread(_socketListener.StartListening)
        {
            IsBackground = true,
            Name = "AsynchronousSocketListener.StartListening"
        }.Start();

        // Initialize services that you need before app activation
        await InitializeAsync();

        if (_saveSettings.IndexConnectToDiscordRPC >= 0 && _saveSettings.IndexConnectToDiscordRPC < _mainService.NroAccounts.Count)
            _saveSettings.AccountConnectToDiscordRPC = _mainService.NroAccounts[_saveSettings.IndexConnectToDiscordRPC];

        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        if (mutex.WaitOne(TimeSpan.Zero, true))
        {
            //if (args.Any(s => s == "--disable-discord-rich-presence"))
            //    isDiscordRichPresenceDisabled = true;

            discordClient = new DiscordRpcClient("1055462814166294559")
            {
                ShutdownOnly = true
            };
            if (isDiscordRichPresenceDisabled)
                return;
            discordClient.Initialize();

            //App.Main();
            if (!isDiscordRichPresenceDisabled)
            {
                discordClient?.ClearPresence();
                discordClient?.Dispose();
            }
            mutex.ReleaseMutex();
        }
        else
        {
            Process otherInstance = Process
                .GetProcessesByName(Assembly.GetEntryAssembly()?.GetName().Name)
                .First(p => p.MainWindowHandle != IntPtr.Zero);

            Utilities.ShowWindowAsync(otherInstance.MainWindowHandle, 9);
            Utilities.SetForegroundWindow(otherInstance.MainWindowHandle);
        }

        _ = Task.Run(async () =>
        {
            await CheckUpdateAndNotification();
            var mainWindow = Utilities.GetMainWindow();
            mainWindow.Dispatcher.Invoke(() => mainWindow.Title = Utilities.GetWindowTitle());
            Utilities.SetPresence();
        }, cancellationToken);

        _isInitialized = true;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    private async Task InitializeAsync()
    {
        if (!_isInitialized)
        {
            _mainService.LoadServers();
            await _mainService.LoadAccountsAsync();
        }
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (!isDiscordRichPresenceDisabled)
            discordClient?.Dispose();
        MessageBox.Show(Application.Current.MainWindow, $"Có lỗi xảy ra:{Environment.NewLine}{e.ExceptionObject}", "QLTK", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private async Task CheckUpdateAndNotification()
    {
        if (_appConfig.LinkNotification is null)
            throw new InvalidOperationException(nameof(_appConfig.LinkNotification) + " is not configured!");

        try
        {
            using var client = new HttpClient();

            string linkNotification = _appConfig.LinkNotification;
            string[] notifications = (await client.GetStringAsync(linkNotification)).Split('\n');

            if (_saveSettings.VersionNotification != notifications[0])
            {
                for (int i = 1; i < notifications.Length; i++)
                {
                    notifications[i] = notifications[i].Trim();
                    if (!string.IsNullOrWhiteSpace(notifications[i]))
                    {
                        MessageBox.Show(
                            messageBoxText: notifications[i],
                            caption: "Thông báo",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                _saveSettings.VersionNotification = notifications[0];
            }

            switch (currentDevelopStatus = await GetCurrentDevelopStatus())
            {
                case DevelopStatus.None:
                    throw new InvalidOperationException(nameof(currentDevelopStatus) + " is not initialized!");
                case DevelopStatus.NormalUser:
                    break;
                case DevelopStatus.Developing:
                    new Thread(() =>
                    Utilities.MessageBoxNative(Process.GetCurrentProcess().MainWindowHandle, "Nếu bạn có ý tưởng hay chức năng mới, đừng ngại ngần mà hãy đóng góp cho Mod Cộng Đồng!", "Thông báo", 0x00000040 | 0x00040000)
                    ).Start();
                    break;
                case DevelopStatus.OldVersion:
                    new Thread(() =>
                    {
                        if (Utilities.MessageBoxNative(Process.GetCurrentProcess().MainWindowHandle, $"Đã có phiên bản mới!{Environment.NewLine}Bạn có muốn cập nhật không?", "Cập nhật", 0x00000004 | 0x00000040 | 0x00040000) == 6)
                            Process.Start("https://github.com/pk9r327/Dragonboy");
                    }).Start();
                    break;
            }

        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show("Không thể kết nối đến máy chủ!" + Environment.NewLine + ex, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Có lỗi xảy ra:" + Environment.NewLine + ex, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async Task<DevelopStatus> GetCurrentDevelopStatus()
    {
        try
        {
            using var client = new HttpClient();

            string remoteInfoString = await client.GetStringAsync(_appConfig.LinkHash);
            string[] remoteInfo = remoteInfoString.Split('\n');

            // hash check
            string hashGameAssemblyRemote = remoteInfo[0].TrimStart('\ufeff');
            string hashQLTKRemote = remoteInfo[2];
            string hashGameAssemblyLocal = Utilities.GetHashFile(GameAssemblyPath);
            string hashQLTKLocal = Utilities.GetHashFile(QLTKPath);
            if (hashQLTKLocal == hashQLTKRemote && hashGameAssemblyLocal == hashGameAssemblyRemote)
                return DevelopStatus.NormalUser;

            // time stamp check
            int timeStampGameAssemblyRemote = int.Parse(remoteInfo[1]);
            int timeStampQLTKRemote = int.Parse(remoteInfo[3]);
            int timeStampGameAssemblyLocal = Utilities.GetTimeStampFile(GameAssemblyPath);
            int timeStampQLTKLocal = Utilities.GetTimeStampFile(QLTKPath);
            if (timeStampGameAssemblyLocal >= timeStampGameAssemblyRemote || timeStampQLTKLocal >= timeStampQLTKRemote)
                return DevelopStatus.Developing;
            if (timeStampGameAssemblyLocal < timeStampGameAssemblyRemote || timeStampQLTKLocal < timeStampQLTKRemote)
                return DevelopStatus.OldVersion;
        }
        catch (HttpRequestException ex)
        {
            MessageBox.Show("Không thể kết nối đến máy chủ!" + Environment.NewLine + ex, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            return DevelopStatus.NormalUser;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Có lỗi xảy ra:" + Environment.NewLine + ex, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            return DevelopStatus.NormalUser;
        }

        return DevelopStatus.None;
    }
}
