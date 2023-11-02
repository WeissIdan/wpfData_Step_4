using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfData.Model;
using wpfData_Step_4.Model;
using wpfData_Step_4.ViewModel;

namespace wpfData.ViewModel
{
    internal class SnackDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Snack() as BaseEntity;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Snack snack = (Snack)entity;
            snack.Id = int.Parse(reader["Id"].ToString());
            snack.SnackName = reader["SnackName"].ToString();
            snack.Calories = int.Parse(reader["Calories"].ToString());
            snack.IsSour = bool.Parse(reader["IsSour"].ToString());
            return snack;
        }

        public SnackList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM tblSnacks";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }

        public Snack SelectById(int id)
        {
            command.CommandText = string.Format("SELECT * FROM tblSnacks WHERE (ID = {0})", id);
            SnackList list = new SnackList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public SnackList SelectByUser(int id)
        {
            this.command.CommandText = "SELECT * FROM (tblUsersSnacks INNER JOIN tblSnacks " +
                $"ON tblUsersSnacks.SnackId = tblSnacks.Id) WHERE UserId = {id}";
            ;
            SnackList snacks = new SnackList(base.ExecuteCommand());
            return snacks;

        }
    }
}
