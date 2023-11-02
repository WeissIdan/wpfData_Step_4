using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfData.Model;

namespace wpfData_Step_4.Model
{
    public class User:BaseEntity
    {
        private string firstName;
        private string lastName;
        private string phone;
        private City city;
        private string userName;
        private string password;
        private bool isAdmin;

        private SnackList snacks;
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public City City
        {
            get { return city; }
            set { city = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public SnackList Snacks { get { return snacks; } set { snacks = value; } }
    }

    public class UserList : List<User>
    {
        public UserList() { } //בנאי ברירת מחדל
        public UserList(IEnumerable<User> list) :
            base(list)
        { } //המרה של רשימת קורסים לאוסף של קורסים
        public UserList(IEnumerable<BaseEntity> list) :
            base(list.Cast<User>().ToList())
        { } //המרה כלפי מטה מישות בסיס לרשימת קורסים

    }

}
