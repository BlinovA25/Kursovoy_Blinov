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
    /// Логика взаимодействия для ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        ReviewContext db;
        REVIEWS newRev = new REVIEWS();
        public string RevUserName;

        public ReviewPage(string UN)
        {
            InitializeComponent();
            RevUserName = UN;
            try
            {
                db = new ReviewContext();

                db.Reviews.Load(); // загружаем данные //возникает ошибка!!!
                reviewGrid.ItemsSource = db.Reviews.Local.ToBindingList();
            }
            catch
            { MessageBox.Show("Ошибка загрузки данных из БД!!!"); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //insert into REVIEWS values('User1','Неплохое приложение.');
            if (reviewTB.Text.Length > 0)
            {
                newRev.Review = reviewTB.Text;
                newRev.UserName = RevUserName;
                //newUser.Email = mailTB.Text;

                try
                {
                    db.Database.ExecuteSqlCommand($@"insert into REVIEWS values('{newRev.UserName}','{newRev.Review}');");
                    MessageBox.Show($"Отзыв оставлен, перезагрузите страницу, чтобы увидеть его.");
                }
                catch
                { MessageBox.Show($"Не удалось оставить отзыв."); }
            }
            else
            { MessageBox.Show($"Введите текст отзыва в соответствующее поле."); }

        }
    }
}
