using QLTK.Models;
using QLTK.Services;
using QLTK.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLTK.Views;
/// <summary>
/// Interaction logic for MainPage.xaml
/// </summary>
public partial class MainPage : Page
{
    public static object sizeData = null;

    private static object settings;

    static int width, height;

    private AppConfig _appConfig;
    private SaveSettings _saveSettings;
    private MainViewModel _mainViewModel;
    private MainService _mainService;

    public MainPage()
    {
        InitializeComponent();

        new Thread(() => AsynchronousSocketListener.StartListening())
        {
            IsBackground = true,
            Name = "AsynchronousSocketListener.StartListening"
        }.Start();

        _mainService.LoadAccountsAsync().Wait();
        //_mainService.LoadSaveSettings();
        if (_saveSettings.IndexConnectToDiscordRPC >= 0 && _saveSettings.IndexConnectToDiscordRPC < AccountsDataGrid.Items.Count)
            _saveSettings.AccountConnectToDiscordRPC = AccountsDataGrid.Items[_saveSettings.IndexConnectToDiscordRPC] as NroAccount;
        new Thread(async () =>
        {
            await Utilities.CheckUpdateAndNotification();
            Dispatcher.Invoke(() => Title = Utilities.GetWindowTitle());
            Utilities.SetPresence();
        })
        {
            IsBackground = true,
            Name = "CheckUpdateAndNotification"
        }.Start();
    }

    private static void SendMessageToAccounts(List<NroAccount> accounts, object message)
    {
        var connectedAccounts = accounts.Where(account => account.workSocket?.Connected == true);
        foreach (var account in connectedAccounts)
            account.sendMessage(message);
    }

    private NroAccount GetSelectedAccount()
        => (NroAccount)this.AccountsDataGrid.SelectedItem;

    private List<NroAccount> GetSelectedAccounts()
        => this.AccountsDataGrid.SelectedItems.Cast<NroAccount>().ToList();

    private NroAccount GetInputAccount() => new NroAccount()
    {
        username = this.UsernameTextBox.Text,
        password = this.PasswordPasswordBox.Password,
        indexServer = this.ServerComboBox.SelectedIndex,
    };

    #region Save

    #endregion

    //private void LoadSaveSettings()
    //{
    //    this.TextBoxSize.Text = _saveSettings.Size;
    //    this.ComboBoxLowGraphic.SelectedIndex = _saveSettings.LowGraphic;
    //    this.ComboBoxTypeSize.SelectedIndex = _saveSettings.TypeSize;
    //    this.RowDetailsModeComboBox.SelectedIndex = _saveSettings.RowDetailsMode;
    //}


    #region Processes
    private async Task ShowWindowAsync(IntPtr hWnd)
    {
        Utilities.ShowWindowAsync(hWnd, 1);
        Utilities.SetForegroundWindow(hWnd);
        await Task.Delay(100);

        Utilities.GetWindowRect(hWnd, out RECT rect);

        int xBase = (int)this.ActualWidth;

        double primaryScreenWidth = SystemParameters.PrimaryScreenWidth;
        double primaryScreenHeight = SystemParameters.PrimaryScreenHeight;

        if (rect.left < xBase || rect.right > primaryScreenWidth ||
            rect.top < 0 || rect.bottom > primaryScreenHeight)
        {
            Utilities.MoveWindow(
                hWnd: hWnd,
                x: xBase, y: 0,
                width: rect.right - rect.left,
                height: rect.bottom - rect.top,
                bRepaint: true);
        }
    }

    //private void ArrangeAllWindows(int type)
    //{
    //    this.ArrangeWindows(this.GetAllAccounts(), type);
    //}

    #endregion

    #region Send
    private void SendChatToSelectedAccounts()
    {
        var accounts = this.GetSelectedAccounts();
        if (accounts.Count() == 0)
        {
            MessageBox.Show("Vui lòng chọn tài khoản");
            return;
        }

        SendMessageToAccounts(accounts, new
        {
            action = "chat",
            text = this.TextBoxChat.Text
        });
    }

    private void SendKeyPressToSelectedAccounts(int keyCode)
    {
        SendMessageToAccounts(this.GetSelectedAccounts(), new
        {
            action = "keyPress",
            keyCode
        });
    }

    private void SendKeyReleaseToSelectedAccounts(int keyCode)
    {
        SendMessageToAccounts(this.GetSelectedAccounts(), new
        {
            action = "keyRelease",
            keyCode
        });
    }
    #endregion

    #region KeyPress
    private static int GetKeyCode(Button button)
    {
        int keyCode;
        switch (button.Content)
        {
            case "▲":
                keyCode = -1;
                break;
            case "▼":
                keyCode = -2;
                break;
            case "◀":
                keyCode = -3;
                break;
            case "▶":
                keyCode = -4;
                break;
            case "↲":
                keyCode = -5;
                break;
            case "F1":
                keyCode = -21;
                break;
            case "F2":
                keyCode = -22;
                break;
            default:
                keyCode = ((string)button.Content)[0];
                break;
        }
        return keyCode;
    }

    private static int GetKeyCode(KeyEventArgs e)
    {
        int keyCode;
        switch (e.Key)
        {
            case Key.Up:
                keyCode = -1;
                break;
            case Key.Down:
                keyCode = -2;
                break;
            case Key.Left:
                keyCode = -3;
                break;
            case Key.Right:
                keyCode = -4;
                break;
            case Key.Enter:
                keyCode = -5;
                break;
            case Key.F1:
                keyCode = -21;
                break;
            case Key.F2:
                keyCode = -22;
                break;
            case Key.Tab:
                keyCode = -26;
                break;
            case Key.Space:
                keyCode = 32;
                break;
            case Key.Back:
                keyCode = -8;
                break;
            case Key.Oem2:
                keyCode = 47;
                break;
            default:
                keyCode = (int)e.Key;
                if (keyCode >= 34 && keyCode <= 43)
                    keyCode += 14;
                else if (keyCode >= 44 && keyCode <= 69)
                    keyCode += 53;
                break;
        }
        return keyCode;
    }

    private void KeyPressButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var button = (Button)sender;
        int keyCode = GetKeyCode(button);

        if (keyCode == 0)
            return;

        this.SendKeyPressToSelectedAccounts(keyCode);
    }

    private void KeyPressButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var button = (Button)sender;
        int keyCode = GetKeyCode(button);

        if (keyCode == 0)
            return;

        this.SendKeyReleaseToSelectedAccounts(keyCode);
    }

    private void Control_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        int keyCode = GetKeyCode(e);
        e.Handled = true;

        if (keyCode == 0)
            return;

        this.SendKeyPressToSelectedAccounts(keyCode);
    }

    private void Control_PreviewKeyUp(object sender, KeyEventArgs e)
    {
        int keyCode = GetKeyCode(e);
        e.Handled = true;

        if (keyCode == 0)
            return;

        this.SendKeyReleaseToSelectedAccounts(keyCode);
    }
    #endregion

    private void AccountsDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        ((NroAccount)e.Row.Item).number = e.Row.GetIndex();
    }

    private void AccountsDataGird_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (this.AccountsDataGrid.SelectedItem is NroAccount account)
        {
            this.UsernameTextBox.Text = account.username;
            this.PasswordPasswordBox.Password = account.password;
            this.ServerComboBox.SelectedIndex = account.indexServer;
            canSetRichPresence = false;
            if (account.Equals(_saveSettings.AccountConnectToDiscordRPC))
                IsDisplayInDiscordRichPresence.IsChecked = true;
            else
                IsDisplayInDiscordRichPresence.IsChecked = false;
            canSetRichPresence = true;
        }
    }

    private async void AccountsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        
    }

    private void SelectAllButton_Click(object sender, RoutedEventArgs e)
    {
        this.AccountsDataGrid.SelectedItems.Clear();
        _mainViewModel.NroAccounts.ForEach(
            a => this.AccountsDataGrid.SelectedItems.Add(a));
    }

    private async void AddAccountButton_Click(object sender, RoutedEventArgs e)
    {
        _mainViewModel.NroAccounts.Add(this.GetInputAccount());
        this.AccountsDataGrid.Items.Refresh();
        await _mainService.SaveAccountsAsync();
    }

    private async void EditAccountButton_Click(object sender, RoutedEventArgs e)
    {
        var account = this.GetSelectedAccount();
        if (account == null)
        {
            MessageBox.Show("Vui lòng chọn tài khoản");
            return;
        }

        var inputAccount = this.GetInputAccount();
        account.username = inputAccount.username;
        account.password = inputAccount.password;
        account.indexServer = inputAccount.indexServer;

        await _mainService.SaveAccountsAsync();
        this.AccountsDataGrid.Items.Refresh();
    }

    private void ChatButton_Click(object sender, RoutedEventArgs e)
    {
        this.SendChatToSelectedAccounts();
    }

    private void ChatTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return)
        {
            this.ChatButton_Click(sender, null);
            e.Handled = true;
        }
    }

    private void IsDisplayInDiscordRichPresence_Checked(object sender, RoutedEventArgs e)
    {
        if (!canSetRichPresence)
            return;
        _saveSettings.IndexConnectToDiscordRPC = AccountsDataGrid.SelectedIndex;
        _saveSettings.AccountConnectToDiscordRPC = AccountsDataGrid.SelectedItem as NroAccount;
        Utilities.SetPresence();
    }

    private void IsDisplayInDiscordRichPresence_Unchecked(object sender, RoutedEventArgs e)
    {
        if (!canSetRichPresence)
            return;
        _saveSettings.IndexConnectToDiscordRPC = -1;
        _saveSettings.AccountConnectToDiscordRPC = null;
        Utilities.SetPresence();
    }

    private void AccountsDataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var args = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
        {
            RoutedEvent = MouseWheelEvent
        };

        AccountsScrollViewer.RaiseEvent(args);
    }
}
