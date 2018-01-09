using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Entity
{
    public class Users
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return "ID: " + id + " ||  Name:" + name + "  ||  Password: " + password;
        }
    }
}
