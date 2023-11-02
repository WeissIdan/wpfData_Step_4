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
using wpfData_Step_4.Model;
using wpfData_Step_4.ViewModel;

namespace wpfData_Step_4
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserDB Udb = new UserDB();
            User newUser = new User();
            newUser.Password = tbxPassword.Password;
            newUser.UserName = tbxID.Text;
            User afterLogin = Udb.Login(newUser);
            if (afterLogin == null)
            {
                MessageBox.Show("error logging in, check values");
            }
            else
            {
                if (afterLogin.IsAdmin)
                {
                    MainWindow mainW = new MainWindow(afterLogin);
                    mainW.Show();
                }
                else
                {
                    MessageBox.Show("successful login, but you are not an admin");
                }

            }

        }
    }
}
