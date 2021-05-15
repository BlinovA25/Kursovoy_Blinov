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
    /// Логика взаимодействия для QuantityWindow.xaml
    /// </summary>
    public partial class QuantityWindow : Window
    {
        public int Q;
        public decimal P;
        public decimal Sum;
        public string FuelName;
        public string UserName;

        public string UN { get; set; }
        OrderContext db;

        public QuantityWindow(string FN, decimal Price, string un)
        {
            InitializeComponent();
            UN = un;
            //MessageBox.Show(UN);

            FuelTypeLabel.Content = FN;
            FuelName = FN;
            P = Price;
        }

        private void QuantityWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //UserNameLabel.Content = UN;
        }

        private void QuantityTB_PreviewTextInput(object sender, TextCompositionEventArgs e) 
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void OrderReady_Click(object sender, RoutedEventArgs e)
        {
            db = new OrderContext();

            try
            { Q = Convert.ToInt32(QuantityTB.Text); }
            catch 
            { }
            Sum = Q * P;

            UserName = UN;
           
            db.Database.ExecuteSqlCommand($@"insert into ORDERS values('{UN}', '{FuelName}', {Q}, {Sum}, 0, getdate(), '');");
            //MessageBox.Show($"Пользователь {UN} зарегистрирован.");
            this.DialogResult = false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void OrderReady_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void QuantityTB_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
