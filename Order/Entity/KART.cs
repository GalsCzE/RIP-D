using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Entity
{
    public class KART
    {
        [PrimaryKey]
        public int ID { get; set; }
        public int ID_objednavky { get; set; }
        public int ID_products { get; set; }
        public int Ammount { get; set; }
        public int Price_products { get; set; }
        public string Name_products { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            if (Status != "Skryto")
            {
                return "ID: " + ID + "  || ID_objednavky: " + ID_objednavky + "  || ID_products: " + ID_products + "  || Name: " + Name_products + " || Price: " + Price_products + "  ||Vytvořeno: " + Created + "  || Mnozstvi: " + Ammount + "  || Stav: " + Status;
            }
            else
            {
                return "";
            }
        }
    }
}
