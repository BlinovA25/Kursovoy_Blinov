using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GasStationProg
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    /// 

    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            AdminWinFrame.Content = new AdminFuelPage();

            if (_CanPingGoogle() != false) 
            { MessageBox.Show("Подключение к интернету установлено!"); }
        }

        private static bool _CanPingGoogle()
        {
            const int timeout = 1000;
            const string host = "google.com";

            var ping = new Ping();
            var buffer = new byte[32];
            var pingOptions = new PingOptions();

            try
            {
                var reply = ping.Send(host, timeout, buffer, pingOptions);
                return (reply != null && reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }


        //кнопки вспомогательного меню
        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow SW = new SettingsWindow();
            SW.ShowDialog();
        }

        private void changeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (mailFrame.Content != null)
            { mailFrame.Content = null; }
            else
            { mailFrame.Content = new AdminEmailPage(); }
        }


        //кнопки основного меню
        private void FuelGridButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWinFrame.Content = new AdminFuelPage();
        }

        private void OrdersGridButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWinFrame.Content = new AdminOrdersPage();
        }

        private void histButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWinFrame.Content = new AdminHistPage();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();

            this.Close();
        }
    }
}
