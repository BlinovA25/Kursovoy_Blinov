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
using System.Net.Mail;
using System.Net;

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

        public string UserName;
        public string UserEmail;
        OrderContext db;
        UserContext UC;

        public AdminOrdersPage()
        {
            InitializeComponent();
            try
            {
                DownloadDB();
            }
            catch
            { MessageBox.Show("Ошибка загрузки данных из БД!!!"); }
        }

        private void DownloadDB() 
        {
            db = new OrderContext();

            db.Orders.Where(u => u.OrderStatus == false).Load();
            orderGrid.ItemsSource = db.Orders.Local.ToBindingList();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UC = new UserContext();

                if (orderGrid.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < orderGrid.SelectedItems.Count; i++)
                    {
                        ORDERS order = orderGrid.SelectedItems[i] as ORDERS;
                        USERS user = new USERS();
                        if (order != null)
                        {
                            order.OrderStatus = true;
                            UserName = order.UserName;

                            user = UC.Users.Find(UserName);
                            UserEmail = user.Email;

                            sendMail(UserEmail);
                        }
                    }
                }
                else { MessageBox.Show("Выберите выполненный заказ!"); }
                db.SaveChanges();
                DownloadDB();
            }

            catch { }
        }


        private void sendMail(string UEM)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("anton253647@gmail.com", "Gas Station Admin");
                // кому отправляем
                MailAddress to = new MailAddress($"{UEM}");//antoha2550@mail.ru
                                                             // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Автозаправка";
                // текст письма
                m.Body = $"Спасибо, что выбрали нашу заправочную станцию!";
                // письмо представляет код html
                m.IsBodyHtml = false;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("anton253647@gmail.com", "253647ab");
                smtp.EnableSsl = true;
                smtp.Send(m);
              
                MessageBox.Show("Сообщение успешно отправлено!");
            }

            catch { MessageBox.Show("Сообщение не отправлено(не указана почта)!"); }
        }


        private void AdminOrdersPage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void SearchBut_Click(object sender, RoutedEventArgs e)
        {
            var N = db.Orders.Local.Where(o => o.UserName.IndexOf(textBoxName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            orderGrid.ItemsSource = N;
        }


    }
}
