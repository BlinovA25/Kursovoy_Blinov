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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public string UN { get; set; }
        public int UID { get; set; }
        //public string UserName;

        public UserWindow()
        {
            InitializeComponent();

            this.Loaded += UserWindow_Loaded;
        }

        private void UserWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserNameLabel.Content = UN;
            UserWinFrame.Content = new UserFuelPage(UN);
        }
       
        private void FuelGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new UserFuelPage(UN);
        }

        private void ReviewsGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new ReviewPage(UN);
        }

        private void OrdersGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new UserOrdersPage(UserNameLabel.Content.ToString());
        }
        
        
        private void OrdersHistButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new UserHistPage(UN);
        }


        //кнопки вспомогательного меню
        private void changeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeInfoFrame.Content != null) 
            { ChangeInfoFrame.Content = null; }
            else 
            { ChangeInfoFrame.Content = new UserChangeInfo(UN); }
                
            //this.Close();
            //MainWindow MW = new MainWindow();
            //MW.ShowDialog();
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow SW = new SettingsWindow();
            SW.ShowDialog();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();

            this.Close();
        }
    }
}
