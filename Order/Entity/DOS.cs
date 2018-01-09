using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Entity
{
    public class DOS
    {
        public int category_id { get; set; }
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }

        public override string ToString()
        {
            return "ID: " + id + " ||  Name:" + name + "  ||  Description: " + description + "  ||  Price: " + price + "EUR  ||  ID kategorie: " + category_id + "  ||  Vytvořeno (created): " + created + "  ||  Upraveno: " + modified;
        }
    }
}
