﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
        //SqlDataAdapter adapter;
        //DataTable usersTable;

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
            pass = GetHash(pass);

            if (pass.Length < 1)
            {
                //passwordTB.ToolTip = "Неверный пароль";
                //passwordTB.Background = Brushes.DarkRed;
            }
            else
            {
                //passwordTB.Background = Brushes.Transparent;

                DB = new UserContext();
                USERS authUser = null;
                authUser = DB.Users.Where(u => u.UserName == login && u.UserPass == pass).FirstOrDefault();
                
                if (authUser != null)
                {
                    if (authUser.adm == true)
                    {
                        AdminWindow AW = new AdminWindow();
                        AW.Show();
                        this.Close();
                    }
                    else
                    {
                        UserWindow UW = new UserWindow();
                        UW.UN = login;
                        UW.Show();
                        this.Close();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует!"); 
                }

            } 
        }

        public static string GetHash(string password) 
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }


        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            //вызов окна регистрации пользователей
            RegistrationWindow RW = new RegistrationWindow();
            RW.ShowDialog();

            //MainWindow.Hide();
        }

        private void setButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow SW = new SettingsWindow();
            SW.ShowDialog();
        }

    }
}
