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
        public UserWindow()
        {
            InitializeComponent();
        }

        private void FuelGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new UserFuelPage();
        }

        private void OrdersGridButton_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void ReviewsGridButton_Click(object sender, RoutedEventArgs e)
        {
            UserWinFrame.Content = new ReviewPage();
        }

        private void OrdersHistButton_Click(object sender, RoutedEventArgs e)
        {

        }


        //кнопки вспомогательного меню
        private void changeUserButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
