using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AdminOrdersPage.xaml
    /// </summary>
    /// 



    public partial class AdminOrdersPage : Page
    {
        //string connectionString;
        //SqlDataAdapter adapter;
        //DataTable orderTable;
        OrderContext db;

        public AdminOrdersPage()
        {
            InitializeComponent();

            try
            {
                db = new OrderContext();

                //ORDERS ord = null;
                //ord = db.Orders.Where(o => o.OrderStatus == 0).SelectMany<ORDERS>;

                //var query = db.Orders.Where(u => u.OrderStatus > 0).OrderBy(u => u.idOrder);
                db.Orders.Where(u => u.OrderStatus == 0).Load(); // загружаем данные //возникает ошибка!!!
                orderGrid.ItemsSource = db.Orders.Local.ToBindingList();


                ////db.Dispose();
            }
            catch
            { MessageBox.Show("Ошибка загрузки данных из БД!!!"); }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();

            db.Database.ExecuteSqlCommand($@"update ORDERS set ReadyTime = getdate() where OrderStatus = 1;");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (orderGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < orderGrid.SelectedItems.Count; i++)
                {
                    ORDERS order = orderGrid.SelectedItems[i] as ORDERS;
                    if (order != null)
                    {
                        db.Orders.Remove(order);
                    }
                }
            }
            db.SaveChanges();
        }

        private void AdminOrdersPage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }




        //connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        //private void UpdateDB()
        //{
        //    SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
        //    adapter.Update(orderTable);
        //}

        //private void DownloadDB(string sql)
        //{
        //    //string sql = "select o.idOrder, u.UserName, o.idFuel, o.NumOfL, o.OrderSum , o.ArrTime , o.OrderStatus from ORDERS o inner join USERS u on o.idUser = u.UserID where o.OrderStatus = 0;";
        //    orderTable = new DataTable();
        //    SqlConnection connection = null;

        //    try
        //    {
        //        connection = new SqlConnection(connectionString);
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        adapter = new SqlDataAdapter(command);

        //        connection.Open();
        //        adapter.Fill(orderTable);
        //        fuelGrid.ItemsSource = orderTable.DefaultView;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        MessageBox.Show("ошибка");
        //    }
        //    finally
        //    {
        //        if (connection != null)
        //            connection.Close();
        //    }
        //}

        ////private void EditRow(DataView view)
        ////{
        ////    view.AllowEdit = true;
        ////    view[0].BeginEdit();
        ////    view[0]["OrderStatus"] = "True";
        ////    //view[0]["OrderStatus"] = 1;
        ////    view[0].EndEdit();
        ////}

        ////private void Change()
        ////{
        ////    if (fuelGrid.SelectedItems != null)
        ////    {
        ////        for (int i = 0; i < fuelGrid.SelectedItems.Count; i++)
        ////        {
        ////            DataView dataView = fuelGrid.SelectedItems[i] as DataView;
        ////            if (dataView != null)
        ////            {
        ////                EditRow(dataView);
        ////                //DataRow dataRow = (DataRow)dataView.Row;
        ////                //dataRow.Delete();
        ////            }
        ////        }
        ////    }
        ////    UpdateDB();
        ////}

        //private void readyButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
        //    adapter.Update(orderTable);
        //}



        //private void downloadButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string sql = "select idOrder, UserName, idFuel, NumOfL, OrderSum , ArrTime , OrderStatus from OrderView;"; //ORDERS o inner join USERS u on o.idUser = u.UserID where o.OrderStatus = 0;;
        //    DownloadDB(sql);
        //}

    }
}
