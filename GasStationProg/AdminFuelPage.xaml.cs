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
    /// Логика взаимодействия для AdminFuelPage.xaml
    /// </summary>
    public partial class AdminFuelPage : Page
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable fuelTable;

        public AdminFuelPage()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(fuelTable);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (fuelGrid.SelectedItems != null)
            {
                for (int i = 0; i < fuelGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = fuelGrid.SelectedItems[i] as DataRowView;
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
            string sql = "select * from FUEL;";
            fuelTable = new DataTable();
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(fuelTable);
                fuelGrid.ItemsSource = fuelTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("ошибка");
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
