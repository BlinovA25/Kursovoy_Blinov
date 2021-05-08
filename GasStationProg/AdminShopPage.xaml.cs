using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Логика взаимодействия для AdminShopPage.xaml
    /// </summary>
    public partial class AdminShopPage : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable shopTable;

        public AdminShopPage()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(shopTable);
        }

        
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            { UpdateDB(); }
            catch
            { MessageBox.Show("Update невозможен!"); }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (shopGrid.SelectedItems != null)
            {
                for (int i = 0; i < shopGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = shopGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }

        private void downloadButton_Click(object sender, RoutedEventArgs e)
        {
            string sql = "begin tran; select * from SHOPITEMS; commit tran;";
            shopTable = new DataTable();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(shopTable);
                shopGrid.ItemsSource = shopTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
        
        
        private void addPicButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = ""; // Default file name
                dlg.DefaultExt = ".png"; // Default file extension

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(dlg.FileName);
                    image.EndInit();

                    if (shopGrid.SelectedItems != null)
                    {
                        for (int i = 0; i < shopGrid.SelectedItems.Count; i++)
                        {
                            DataRowView datarowView = shopGrid.SelectedItems[i] as DataRowView;
                            if (datarowView != null)
                            {
                                DataRow dataRow = (DataRow)datarowView.Row;
                                dataRow["ItemPhoto"] = dlg.FileName;
                            }
                        }
                    }
                    UpdateDB();
                }
            }
            catch 
            {
                MessageBox.Show("Невозможно добавить картинку.");
            }
        }

    }
}
