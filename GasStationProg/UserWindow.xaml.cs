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

        public UserWindow()
        {
            InitializeComponent();
            this.Loaded += UserWindow_Loaded;
        }
        private void UserWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UserNameLabel.Content = UN;
        }
       
        private void FuelGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new UserFuelPage();
        }

        private void ReviewsGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new ReviewPage();
        }

        private void OrdersGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new UserOrdersPage(UID);
        }
        
        
        private void OrdersHistButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new UserHistPage(UID);
        }


        //кнопки вспомогательного меню
        private void changeUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow MW = new MainWindow();
            MW.ShowDialog();
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
