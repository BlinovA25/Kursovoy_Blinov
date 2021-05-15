using System;
using System.Collections.Generic;
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
        public AdminEmailPage()
        {
            InitializeComponent();
        }

        private void sendMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("anton253647@gmail.com", "Gas Station Admin");
                // кому отправляем
                MailAddress to = new MailAddress("antoha2550@mail.ru");//почта пользователя
                                                                       // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Автозаправка";
                // текст письма
                m.Body = $"<h2>Ваш заказ будет готов через 10 минут, ждём Вас на нашей автозаправочной станции!</h2>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("anton253647@gmail.com", "253647ab");
                smtp.EnableSsl = true;
                smtp.Send(m);
                //Console.Read();
            }

            catch { }
        }
    }
}
