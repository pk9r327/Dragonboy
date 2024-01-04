using QLTK.Models;
using QLTK.Properties;
using QLTK.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLTK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainService _mainService;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Closed(object sender, EventArgs e)
        {
            _mainService.KillAllProcesses();

            await _mainService.SaveAccountsAsync();
            await _mainService.SaveSettingsAsync();
        }
    }
}
