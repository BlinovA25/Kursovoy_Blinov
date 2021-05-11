﻿using System;
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
        public QuantityWindow()
        {
            InitializeComponent();

            FuelTypeLabel.Content = "АИ-95";
        }

        private void OrderReady_Click(object sender, RoutedEventArgs e)
        {
            //Odb.Database.ExecuteSqlCommand($@"");
            //MessageBox.Show($"Пользователь {newUser.UserName} зарегистрирован.");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
