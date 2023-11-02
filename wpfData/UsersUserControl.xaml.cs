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
using wpfData_Step_4.ViewModel;
using wpfData_Step_4.Model;


namespace wpfData_Step_4
{
    /// <summary>
    /// Interaction logic for UsersUserControl.xaml
    /// </summary>
    public partial class UsersUserControl : UserControl
    {
        private UserDB userDB;
        public UsersUserControl()
        {
            InitializeComponent();

            userDB = new UserDB();
            peopleListView.ItemsSource = userDB.SelectAll();
        }

        private void peopleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User people = peopleListView.SelectedItem as User;
            City city = people.City; //המרה של השורה הראשונה שנבחרה לעצם מסוג עיר
        }
    }
}
