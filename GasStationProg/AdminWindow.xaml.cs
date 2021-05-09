using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        //кнопки вспомогательного меню
        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow SW = new SettingsWindow();
            SW.ShowDialog();
        }

        private void changeUserButton_Click(object sender, RoutedEventArgs e)
        {

        }


        //кнопки основного меню
        private void FuelGridButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWinFrame.Content = new AdminFuelPage();
        }

        private void OrdersGridButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
