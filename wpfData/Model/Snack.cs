using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfData_Step_4.Model;

namespace wpfData.Model
{
    public class Snack : BaseEntity
    {
        private string snackName;
        private int calories;
        private bool isSour;

        public string SnackName { get { return snackName; } set { snackName = value; } }
        public int Calories { get { return calories; } set { calories = value; } }
        public bool IsSour { get { return isSour; } set { isSour = value; } }
    }
    public class SnackList : List<Snack>
    {
        public SnackList() { } //בנאי ברירת מחדל
        public SnackList(IEnumerable<Snack> list) :
            base(list)
        { } //המרה של רשימת קורסים לאוסף של קורסים
        public SnackList(IEnumerable<BaseEntity> list) :
            base(list.Cast<Snack>().ToList())
        { } //המרה כלפי מטה מישות בסיס לרשימת קורסים

    }
}
