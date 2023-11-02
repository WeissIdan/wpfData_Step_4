using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using wpfData.Model;
using wpfData.ViewModel;
using wpfData_Step_4.Model;

namespace wpfData_Step_4.ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            SnackDB SDB = new SnackDB();
            User user = (User)entity;
            user.Id = (int)reader["PersonID"];
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.Phone = reader["Phone"].ToString();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.IsAdmin = bool.Parse(reader["IsAdmin"].ToString());

            // השלמת הבאת נתוני עיר לפי קוד העיר
            int cityID = (int)reader["CityID"];
            CityDB cityDB = new CityDB();
            user.City = cityDB.SelectById(cityID);
            user.Snacks = SDB.SelectByUser(user.Id);
            return user;
        }


        public UserList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM TblUsers";
            UserList list = new UserList(base.ExecuteCommand());
            return list;
        }

        public User SelectById(int id)
        {
            command.CommandText = string.Format("SELECT * FROM TblUsers WHERE (ID = {0})", id);
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
        public User Login(User user)
        {
            string q = $"SELECT * FROM TblUsers WHERE (UserName = '{user.UserName}') AND ([Password] = '{user.Password}')";
            command.CommandText = q;
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public UserList SelectBySnack(int id)
        {
            this.command.CommandText = "SELECT * FROM (tblUsersSnacks INNER JOIN tblSnacks " +
                                        $"ON tblUsersSnacks.UserId = tblUsers.PersonId) WHERE SnackId = {id}";
            UserList snacks = new UserList(base.ExecuteCommand());
            return snacks;

        }
    }
}

