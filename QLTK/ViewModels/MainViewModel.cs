using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QLTK.Models;
using QLTK.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace QLTK.ViewModels;
public partial class MainViewModel : ObservableObject
{
    private MainService _mainService;

    public object SizeData { get; private set; }

    public List<NroServer> NroServers => _mainService.NroServers;

    public List<NroAccount> NroAccounts => _mainService.NroAccounts;

    public bool GameFullScreen => _mainService.GameFullScreen;

    [ObservableProperty]
    private NroAccount? _selectedAccount;

    [ObservableProperty]
    private string _sizeText;

    [ObservableProperty]
    private bool _enableMainGrid = true;

    [ObservableProperty]
    private int _typeSizeIndex = 1;

    [ObservableProperty]
    private int _lowGraphic;


    private bool _canSetRichPresence;


    public MainViewModel()
    {
    }

    [RelayCommand]
    async Task DeleteAccounts(IEnumerable<NroAccount> accounts)
    {
        _mainService.DeleteAccounts(accounts);
        await _mainService.SaveAccountsAsync();
    }

    [RelayCommand]
    async Task Login(IEnumerable<NroAccount> accounts)
    {
        if (!UpdateSizeData())
        {
            MessageBox.Show("Kích thước cửa sổ không hợp lệ");
            return;
        }

        if (!accounts.Any())
        {
            MessageBox.Show("Vui lòng chọn tài khoản");
            return;
        }

        EnableMainGrid = false;
        await _mainService.OpenGamesAsync(accounts);
        EnableMainGrid = true;
    }

    [RelayCommand]
    async Task LoginAll()
    {
        if (!UpdateSizeData())
        {
            MessageBox.Show("Kích thước cửa sổ không hợp lệ");
            return;
        }

        EnableMainGrid = false;
        await _mainService.OpenGamesAsync(NroAccounts);
        EnableMainGrid = true;
    }

    [RelayCommand]
    void KillProcesses(IEnumerable<NroAccount> accounts)
    {
        if (!accounts.Any())
        {
            MessageBox.Show("Vui lòng chọn tài khoản");
            return;
        }

        var runningAccounts = accounts.Where(account => account.process?.HasExited == false);
        foreach (var account in runningAccounts)
            account.process.Kill();
    }

    [RelayCommand]
    async Task ArrangeWindows1(IEnumerable<NroAccount> accounts)
    {
        EnableMainGrid = false;
        await _mainService.ShowAndArrangeWindowsAsync(accounts, 1);
        EnableMainGrid = true;
    }

    [RelayCommand]
    async Task ArrangeWindows2(IEnumerable<NroAccount> accounts)
    {
        EnableMainGrid = false;
        await _mainService.ShowAndArrangeWindowsAsync(accounts, 2);
        EnableMainGrid = true;
    }

    async Task HandleAccountsDoubleClick()
    {
        if (SelectedAccount is not null)
        {
            _canSetRichPresence = true;
            EnableMainGrid = false;

            if (ExistedWindow(account, out IntPtr hWnd))
            {
                if (!FullScreenCheckBox.IsChecked.Value)
                    await this.ShowWindowAsync(hWnd);
                this.MainGrid.IsEnabled = true;
                return;
            }

            if (!this.UpdateSizeData())
            {
                MessageBox.Show("Kích thước cửa sổ không hợp lệ");
                this.MainGrid.IsEnabled = true;
                return;
            }

            if (account.Equals(_saveSettings.AccountConnectToDiscordRPC))
                IsDisplayInDiscordRichPresence_Checked(sender, null);
            await this.OpenGameAsync(account);

            this.MainGrid.IsEnabled = true;
        }
    }

    bool UpdateSizeData()
    {
        var match = GameSizeRegex().Match(SizeText);

        if (!match.Success)
            return false;

        var width = int.Parse(match.Groups[1].Value);
        var height = int.Parse(match.Groups[2].Value);
        var sizeData = new
        {
            width,
            height,
            typeSize = TypeSizeIndex + 1,
            lowGraphic = LowGraphic,
            fullScreen = GameFullScreen
        };
        return true;
    }

    [GeneratedRegex(@"^\s*(\d+)x(\d+)\s*$")]
    private static partial Regex GameSizeRegex();
}
