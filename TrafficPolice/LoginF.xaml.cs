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
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для LoginF.xaml
    /// </summary>
    public partial class LoginF : Window
    {
        public LoginF()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBconnection bconnection = new MyDBconnection())
            {
                bconnection.Staffs.Load();
                var driver = bconnection.Staffs.Where(x => x.Login == LoginTbox.Text.ToString() && x.Password == PasswordTbox.Text.ToString()) ;
                foreach (Staff staff in driver) ;
                if (driver.Count() != 1) { MessageBox.Show("Такого пользователя не существует");  LoginClass.key = false;return; } else { LoginClass.key = true; LoginClass.LoginName = LoginTbox.Text.ToString(); LoginClass.LoginPassword = PasswordTbox.Text.ToString(); ; Close(); }
            }
        }
    }
}
