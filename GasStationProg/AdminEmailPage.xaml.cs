using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для AdminEmailPage.xaml
    /// </summary>
    public partial class AdminEmailPage : Page
    {
        public string Email;
        UserContext db = new UserContext();
        public AdminEmailPage()
        {
            InitializeComponent();
            db.Users.Load();
            Users.ItemsSource = db.Users.Local.Where(u => u.adm == false).Select(u => u.UserName);
            
        }

        private void sendMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("anton253647@gmail.com", "Gas Station Admin");
                // кому отправляем
                MailAddress to = new MailAddress($"{Email}");//antoha2550@mail.ru
                                                                       // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Автозаправка";
                // текст письма
                m.Body = $"{mailtextTB.Text}";
                // письмо представляет код html
                m.IsBodyHtml = false;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("anton253647@gmail.com", "253647ab");
                smtp.EnableSsl = true;
                smtp.Send(m);
                //Console.Read();

                mailtextTB.Text = "";
            }

            catch { }
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            USERS user = db.Users.Local.Where(u => u.UserName == Users.SelectedItem).FirstOrDefault();
            Email = user.Email;
        }
    }
}
