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
using wpfData;
using wpfData_Step_4.Model;

namespace wpfData_Step_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User currentUser;
        public MainWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void City_load()
        {
            dataDockPanel.Children.Clear();
            dataDockPanel.Children.Add(new CityUserControl());
        }
        private void Users_load()
        {
            dataDockPanel.Children.Clear();
            dataDockPanel.Children.Add(new UserUserControl1());
        }

        private void goToLogin(object sender, RoutedEventArgs e)
        {
            LoginWindow lgw = new LoginWindow();
            lgw.ShowDialog();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ((MenuItem)sender).Header.ToString();
                dataDockPanel.Children.Clear();
                switch (name)
                {
                    case "City":
                        City_load();
                        break;
                    case "Users":
                        Users_load();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
