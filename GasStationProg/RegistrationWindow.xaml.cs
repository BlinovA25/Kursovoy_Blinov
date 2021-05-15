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
using System.Windows.Shapes;

namespace GasStationProg
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        UserContext db;
        USERS newUser = new USERS();

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void registrateButton_Click(object sender, RoutedEventArgs e)
        {
            db = new UserContext();

            if (loginTB.Text == "Admin" && passTB.Text == "00000")
            {
                newUser.UserName = loginTB.Text;
                newUser.UserPass = passTB.Text;
                try
                {
                    db.Database.ExecuteSqlCommand($@"insert into USERS values('{newUser.UserName}', '{newUser.UserPass}', ' ', 1, getdate());");
                    MessageBox.Show($"Администратор зарегистрирован успешно.");
                    this.DialogResult = false;
                }
                catch
                { MessageBox.Show($"Пользователь {newUser.UserName} уже существует."); }
            }
            else
            {
                if (loginTB.Text.Length > 2)
                {
                    newUser.UserName = loginTB.Text;

                    if (passTB.Text.Length == 5)
                    {
                        newUser.UserPass = passTB.Text;
                        newUser.Email = mailTB.Text;

                        try
                        {
                            db.Database.ExecuteSqlCommand($@"insert into USERS values('{newUser.UserName}', '{newUser.UserPass}', '{newUser.Email}', 0, getdate());");
                            MessageBox.Show($"Пользователь {newUser.UserName} зарегистрирован.");
                            this.DialogResult = false;
                        }
                        catch
                        { MessageBox.Show($"Пользователь {newUser.UserName} не зарегистрирован, скорее всего это имя уже занято, попробуйте другое."); }
                    }
                    else
                    { MessageBox.Show($"Пароль должен содержать ровно 5 символов."); }
                }
                else
                { MessageBox.Show($"Логин должен содержать от 2 до 10 символов."); }

            }

        }
    }
}
