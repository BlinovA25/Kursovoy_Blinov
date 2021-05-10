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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable usersTable;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
           
        //подключаем тему приложения
            string theme = null;
            theme = "Resources/StandartTheme";
            var uri = new Uri(theme + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = (ResourceDictionary)Application.LoadComponent(uri);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            UserContext DB;

            string login = loginTB.Text.Trim();
            string pass = passwordTB.Password.Trim(); //Text.Trim();

            if (pass.Length < 1)
            {
                //passwordTB.ToolTip = "Неверный пароль";
                passwordTB.Background = Brushes.DarkRed;
            }
            else
            {
                passwordTB.Background = Brushes.Transparent;

                DB = new UserContext();

                USERS authUser = null;
                //using (ApplicationContext DB = new ApplicationContext)
                //{
                    authUser = DB.Users.Where(u => u.UserName == login && u.UserPass == pass).FirstOrDefault();
                //}
                if (authUser != null)
                {
                    //this.DialogResult = true;
                    if (authUser.adm == true)
                    {
                        AdminWindow AW = new AdminWindow();
                        AW.ShowDialog();
                    }
                    else
                    {
                        UserWindow UW = new UserWindow();
                        UW.ShowDialog();
                    }
                }
                else
                {
                    //this.DialogResult = false;
                    //errorTextBlock.Text = ;
                    MessageBox.Show("Такого пользователя не существует!"); 
                }

            } 
        }


        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            //вызов окна регистрации пользователей
            RegistrationWindow RW = new RegistrationWindow();
            RW.ShowDialog();
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow SW = new SettingsWindow();
            SW.ShowDialog();
        }

        private void passwordTB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //passwordTB.PasswordChar = '*';
        }

        //private void passwordTB_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    passwordTB.PasswordChar = '*';
        //}

        //private void enterButton_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
