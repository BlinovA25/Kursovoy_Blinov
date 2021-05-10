using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GasStationProg
{
    /// <summary>
    /// Логика взаимодействия для UserOrdersPage.xaml
    /// </summary>
    public partial class UserOrdersPage : Page
    {
        public UserOrdersPage(int UID)
        {
            OrderContext db;

            InitializeComponent();
            try
            {
                db = new OrderContext();
                db.Orders.Where(u => u.OrderStatus == 0 && u.UserID == UID).Load();
                orderGrid.ItemsSource = db.Orders.Local.ToBindingList();
            }
            catch
            { MessageBox.Show("Ошибка загрузки данных из БД!!!"); }
        }
    }
}
