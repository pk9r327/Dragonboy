using QLTK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLTK.Services;
public class MainService
{
    private AppConfig _appConfig;
    private SaveSettings _saveSettings;

    public int GameWidth { get; set; }
    public int GameHeight { get; set; }
    public bool GameFullScreen { get; set; }

    public List<NroServer> NroServers { get; private set; }

    public List<NroAccount> NroAccounts { get; private set; }

    public MainService()
    {
        InitServers();
    }

    void InitServers()
    {
        NroServers =
        [
            new NroServer("Vũ trụ 1", "dragon1.teamobi.com", 14445),
            new NroServer("Vũ trụ 2", "dragon2.teamobi.com", 14445),
            new NroServer("Vũ trụ 3", "dragon3.teamobi.com", 14445),
            new NroServer("Vũ trụ 4", "dragon4.teamobi.com", 14445),
            new NroServer("Vũ trụ 5", "dragon5.teamobi.com", 14445),
            new NroServer("Vũ trụ 6", "dragon6.teamobi.com", 14445),
            new NroServer("Vũ trụ 7", "dragon7.teamobi.com", 14445),
            new NroServer("Vũ trụ 8", "dragon10.teamobi.com", 14446),
            new NroServer("Vũ trụ 9", "dragon10.teamobi.com", 14447),
            new NroServer("Vũ trụ 10", "dragon10.teamobi.com", 14445),
            new NroServer("Vũ trụ 11", "dragon11.teamobi.com", 14445),
            new NroServer("Võ đài Liên Vũ Trụ", "dragonwar.teamobi.com", 20000),
            new NroServer("Universe 1", "dragon.indonaga.com", 14445, 2),
            new NroServer("Indonaga", "dragon.indonaga.com", 14446, 2),
            .. Utilities.LoadServersFromFile(),
            new NroServer("Local", "127.0.0.1", 14445),
        ];
    }

    public async Task LoadAccountsAsync()
    {
        try
        {
            var encrypted = await File.ReadAllTextAsync(_appConfig.PathAccounts);
            var accountsJson = Utilities.DecryptString(encrypted);

            NroAccounts = LitJson.JsonMapper.ToObject<List<NroAccount>>(accountsJson);
        }
        catch
        {
            NroAccounts = [];
            await SaveAccountsAsync();
        }
    }



    #region Save
    public async Task SaveAccountsAsync()
    {
        try
        {
            if (!Directory.Exists(_appConfig.ModDataFolder))
                Directory.CreateDirectory(_appConfig.ModDataFolder);

            var accountsJson = LitJson.JsonMapper.ToJson(NroAccounts);
            var encrypted = Utilities.EncryptString(accountsJson);

            await File.WriteAllTextAsync(_appConfig.PathAccounts, encrypted);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    public async Task SaveSettingsAsync()
    {
        //_saveSettings.Size = this.TextBoxSize.Text;
        //_saveSettings.LowGraphic = this.ComboBoxLowGraphic.SelectedIndex;
        //_saveSettings.TypeSize = this.ComboBoxTypeSize.SelectedIndex;
        //_saveSettings.RowDetailsMode = this.RowDetailsModeComboBox.SelectedIndex;

        await _saveSettings.SaveAsync();
    }
    #endregion

    public void DeleteAccounts(IEnumerable<NroAccount> accounts)
    {
        foreach (var account in accounts)
        {
            if (account.Equals(_saveSettings.AccountConnectToDiscordRPC))
            {
                _saveSettings.AccountConnectToDiscordRPC = null;
                _saveSettings.IndexConnectToDiscordRPC = -1;
            }
            NroAccounts.Remove(account);
        }
    }

    #region Open Game
    public async Task OpenGamesAsync(IEnumerable<NroAccount> accounts)
    {
        foreach (var account in accounts)
        {
            await OpenGameAsync(account);
        }
    }

    public async Task OpenGameAsync(NroAccount account)
    {
        // If the process is running, do nothing
        if (account.process != null && !account.process.HasExited)
        {
            return;
        }

        account.status = "Đang khởi động...";
        //this.AccountsDataGrid.Items.Refresh();

        AsynchronousSocketListener.WaitingAccounts.Add(account);

        var argumentsBuilder = new StringBuilder()
            .AppendFormat("-port {0} ", _appConfig.PortListener)
            .AppendFormat("-screen-width {0} ", GameWidth)
            .AppendFormat("-screen-height {0} ", GameHeight)
            .AppendFormat("-screen-fullscreen {0}", GameFullScreen);

        var arguments = argumentsBuilder.ToString();

        account.process = Process.Start(_appConfig.PathGame, arguments);

        while (account.process.MainWindowHandle == IntPtr.Zero)
        {
            await Task.Delay(50);
        }

        var hWnd = account.process.MainWindowHandle;
        Utilities.SetWindowText(hWnd, account.username);
        if (!GameFullScreen)
        {
            Utilities.GetWindowRect(hWnd, out RECT rect);
            Utilities.MoveWindow(
                hWnd, x: rect.left - rect.right, y: 0,
                width: rect.right - rect.left,
                height: rect.bottom - rect.top,
                bRepaint: true);
        }
    }
    #endregion

    public void KillAllProcesses()
    {
        foreach (var account in NroAccounts)
            if (account.process?.HasExited == false)
                account.process.Kill();
    }

    public async Task ShowAndArrangeWindowsAsync(IEnumerable<NroAccount> accounts, int type)
    {
        if (GameFullScreen)
            return;

        if (accounts.Count() <= 1)
            accounts = NroAccounts;

        await ShowWindowsAsync(accounts);
        ArrangeWindows(accounts, type);
    }

    public static async Task ShowWindowsAsync(IEnumerable<NroAccount> accounts)
    {
        foreach (var account in accounts)
        {
            if (ExistedWindow(account, out IntPtr hWnd))
            {
                Utilities.ShowWindowAsync(hWnd, 1);
                Utilities.SetForegroundWindow(hWnd);
            }
        }
        await Task.Delay(1000);
    }

    private static void ArrangeWindows(IEnumerable<NroAccount> accounts, int type)
    {
        var maxWidth = SystemParameters.PrimaryScreenWidth;
        var maxHeight = SystemParameters.PrimaryScreenHeight;

        int xBase = (int)Utilities.GetMainWindow().ActualWidth;

        int cx = xBase, cy = 0;

        for (int i = 0; i < accounts.Count(); i++)
        {
            if (!ExistedWindow(accounts.ElementAt(i), out IntPtr hWnd))
                continue;

            if (!Utilities.GetWindowRect(hWnd, out RECT rect))
                continue;

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            Utilities.MoveWindow(hWnd, cx, cy, width, height, true);

            cx += width / type;
            if (cx + width / type > maxWidth)
            {
                cx = xBase;
                cy += height - 5;
            }
            if (cy + height > maxHeight)
            {
                cy = 0;
            }
        }
    }

}
