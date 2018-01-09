using Order.Database;
using Order.Entity;
using Order.WebClient;
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

namespace Order
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int FilterID;
        private int price;
        private string name;
        private string description;
        private static Dat _database;
        private int oid;
        private int iID;
        private int iiID;
        private string Ammount;
        private int amm;
        private string UserNameS;
        private string PasswordS;
        private List<Users> logged_Users;
        //instance databáze
        public static Dat Database
        {
            get
            {
                if (_database == null)
                {
                    var fileHelper = new FileHelper();
                    _database = new Dat(fileHelper.GetFilePath("SQLite.db3"));
                }
                return _database;
            }
        }

        public Rest_web rest = new Rest_web();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Restart()
        {
            List<DOS> apiDOS = rest.getDOS();
            myList.ItemsSource = apiDOS.OrderBy(t => t.id);
            foreach (DOS td in apiDOS)
            {
                //saveDOS(td);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string Fin = FilterIn.Text;
                FilterID = Int32.Parse(Fin);
            }
            catch (Exception dd)
            {
                Console.WriteLine("nastala neočekávaná chyba:" + dd);
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = Name.Text;
        }

        private void sID2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sID2.Text != " ")
            {
                iID = Int32.Parse(sID2.Text);
            }
        }
        private void id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (id.Text != " ")
            {
                iiID = Int32.Parse(id.Text);
            }
        }

        private void oID_TextChanged(object sender, TextChangedEventArgs e)
        {
            oid = Int32.Parse(oID.Text);
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e)
        {
            description = Description.Text;
        }

        private void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string Pri = Price.Text;
                price = Int32.Parse(Pri);
            }
            catch (Exception dd)
            {
                Console.WriteLine("nastala neočekávaná chyba:" + dd);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //  List<DOS> filtered_result = _database.Filterer(FilterID).Result;
            // myList.ItemsSource = _database.Filterer(FilterID).Result;
            List<DOS> apiDOS = rest.getDOS();
            myList.ItemsSource = apiDOS.OrderBy(t => t.id);

        }
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            //  List<DOS> filtered_result = _database.Filterer(FilterID).Result;
            // myList.ItemsSource = _database.Filterer(FilterID).Result;
            if (price != 0)
            {
                List<DOS> apiDOS = rest.getByPrice(price);
                myList.ItemsSource = apiDOS.OrderBy(t => t.id);
            }
            else if (FilterID != 0)
            {
                List<DOS> apiDOS = rest.getByCategory(FilterID);
                myList.ItemsSource = apiDOS.OrderBy(t => t.id);
            }
            else if (iID != 0)
            {
                List<DOS> apiDOS = rest.getByID(iID);
                myList.ItemsSource = apiDOS.OrderBy(t => t.id);
            }
            else
            {
                List<DOS> apiDOS = rest.getDOS();
                myList.ItemsSource = apiDOS.OrderBy(t => t.id);
            }

        }
        private void Write_Click(object sender, RoutedEventArgs e)
        {
            //  List<DOS> filtered_result = _database.Filterer(FilterID).Result;
            // myList.ItemsSource = _database.Filterer(FilterID).Result;
            List<DOS> apiDOS = rest.postWrite(description, name, FilterID, price);
            myList.ItemsSource = apiDOS.OrderBy(t => t.id);

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // List<DOS> filtered_result = _database.Filterer(FilterID).Result;
            //   myList.ItemsSource = _database.Filterer(FilterID).Result;
            List<DOS> apiDOS = rest.postDelete(iID);
            Restart();
            //myList.ItemsSource = apiDOS.OrderBy(t => t.id);

        }


        private void myList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FilterIn.Text = FilterID.ToString();
            Name.Text = e.OriginalSource.ToString();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //  List<DOS> filtered_result = _database.Filterer(FilterID).Result;
            // myList.ItemsSource = _database.Filterer(FilterID).Result;

            List<DOS> apiDOS = rest.postUpdate(description, name, FilterID, price, iID);
            Restart();
            //  myList.ItemsSource = apiDOS.OrderBy(t => t.id);

        }

        private void myList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView neco = (ListView)sender;
            DOS pomg = (DOS)neco.SelectedItem;
            if ((DOS)pomg == null)
            {
                Restart();
            }
            else
            {

                //sID = neco.SelectedItem.ToString();
                iID = pomg.id;
                FilterID = pomg.category_id;
                description = pomg.description;
                name = pomg.name;
                price = pomg.price;

                FilterIn.Text = FilterID.ToString();
                Description.Text = description;
                Name.Text = name;
                Price.Text = price.ToString();
                sID2.Text = iID.ToString();
            }
        }

        private void myObjednavka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Do nothing
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (objednavka.IsSelected)
            {
                List<KART> apiDOS = rest.getObjednavka();
                myObjednavka.ItemsSource = apiDOS.OrderBy(t => t.ID);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Users> apiDOS = rest.getUser(UserNameS, PasswordS);
        }

        private void UsersName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserNameS = UserName.Text;
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordS = Password.Text;
        }

        private void Ammount_TextChanged(object sender, TextChangedEventArgs e)
        {
            Ammount = ammount.Text;
            if (Ammount != " ")
            {
                amm = Int32.Parse(Ammount);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            UserName.Text = " ";
            Password.Text = " ";
            sID2.Text = " ";
            Price.Text = " ";
            Description.Text = " ";
            Name.Text = " ";
            FilterIn.Text = " ";
            ammount.Text = " ";
            id.Text = " ";
        }

        //NEFUNGUJE

       /* private void Login_Click(object sender, RoutedEventArgs e)
        {
            List<Users> apiDOS = rest.LoginUser(UserNameS, PasswordS);
            logged_Users = apiDOS;
            UserData.ItemsSource = apiDOS;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            List<Users> apiDOS = rest.RegisterUser(UserNameS, PasswordS);
            Notice.Content = "Nyní se můžete přihlásit";
        }*/

        private void Objednat_Click(object sender, RoutedEventArgs e)
        {
            if (oid == 0)
            {
                List<KART> apiDOS = rest.buyMeItem(iiID, amm);
                // myObjednavka.ItemsSource = apiDOS.OrderBy(t => t.ID);
            }
            else
            {
                List<KART> apiDOS = rest.editObjednavka(oid, iiID, amm);
            }

        }
    }
}
