using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GasStationProg
{
    /// <summary>
    /// Логика взаимодействия для UserChangeInfo.xaml
    /// </summary>
    public partial class UserChangeInfo : Page
    {
        UserContext db;
        USERS newUser = new USERS();
        public string ChUserName;

        public UserChangeInfo(string UN)
        {
            InitializeComponent();

            ChUserName = UN;
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            db = new UserContext();

            if (loginTB.Text.Length > 2)
            {
                newUser.UserName = loginTB.Text;

                if (passTB.Text.Length == 5)
                {
                    newUser.UserPass = passTB.Text;
                    newUser.Email = mailTB.Text;

                    try
                    {
                        db.Database.ExecuteSqlCommand($@"update USERS set UserName = '{newUser.UserName}', UserPass = '{newUser.UserPass}', Email = '{newUser.Email}' where UserName = '{ChUserName}';");
                        MessageBox.Show($"Информация успешно изменена.");
                    }
                    catch
                    { MessageBox.Show($"Нельзя использовать имя {newUser.UserName}, так как оно уже занято."); }
                }
                else
                { MessageBox.Show($"Пароль должен содержать ровно 5 символов."); }
            }
            else
            { MessageBox.Show($"Логин должен содержать от 2 до 10 символов."); }
        }
    }
}
