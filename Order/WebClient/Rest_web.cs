using Order.Entity;
using RestSharp;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.WebClient
{
    public class Rest_web
    {
        public IServiceClient client = new JsonServiceClient("https://student.sps-prosek.cz").WithCache();
        public List<DOS> getDOS()
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", ""); 

            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<DOS>>(); 
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<DOS> tdl = new List<DOS>();
                tdl.Add(new DOS { description = "error message: " + ex.Message });
                return tdl;
            }
        }

        public List<KART> getKart()
        {

            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
           

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "cart"); 
            request.AddParameter("id_users", "1");
            request.AddParameter("table", "objednavky");

            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<KART>>(); 
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<KART> td2 = new List<KART>();
                return td2;
            }
        }
        public List<KART> getObjednavky()
        {

            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "objednavky"); 
            request.AddParameter("id_users", "1");
            request.AddParameter("table", "");

            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<KART>>();
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<KART> td2 = new List<KART>();
                return td2;
            }
        }

        public List<KART> getObjednavka()
        {

            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "objednavka"); 

            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<KART>>(); 
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<KART> td2 = new List<KART>();
                return td2;
            }
        }

        public List<Users> LoginUser(string name, string password)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "login");
            request.AddParameter("name", name);
            request.AddParameter("pswd", password);

            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<Users>>();
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<Users> td2 = new List<Users>();
                td2.Add(new Users { name = "error message: " + ex.Message });
                return td2;
            }

        }

        public List<Users> RegisterUser(string name, string password)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "register");
            request.AddParameter("name", name);
            request.AddParameter("pswd", password);

            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<Users>>();
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<Users> td2 = new List<Users>();
                td2.Add(new Users { name = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<Users> getUser(string name, string password)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "updateuser"); 
            request.AddParameter("name", name); 
            request.AddParameter("pswd", password); 

            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<Users>>();
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<Users> td2 = new List<Users>();
                td2.Add(new Users { name = "error message: " + ex.Message });
                return td2;
            }
        }

        internal List<DOS> giveMeItem(int iID)
        {
            throw new NotImplementedException();
        }

        public List<DOS> getByCategory(int id)
        {

            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "category"); // replaces matching token in request.Resource
            request.AddParameter("category_id", id); // adds to POST or URL querystring based on Method

            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<DOS>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<DOS> td2 = new List<DOS>();
                td2.Add(new DOS { description = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<DOS> getByPrice(int price)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "price"); // replaces matching token in request.Resource
            request.AddParameter("price", price); // adds to POST or URL querystring based on Method

            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<DOS>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<DOS> td2 = new List<DOS>();
                td2.Add(new DOS { description = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<KART> buyMeItem(int pID, int ammount)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "write_objednavky"); // replaces matching token in request.Resource
            request.AddParameter("id_objednavky", pID);
            request.AddParameter("mnozstvi", ammount);


            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<KART>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<KART> td2 = new List<KART>();
                td2.Add(new KART { description = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<KART> editObjednavka(int oID, int pID, int ammount)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "edit_objednavka"); // replaces matching token in request.Resource
            request.AddParameter("id", pID);
            request.AddParameter("id_objednavky", oID);
            request.AddParameter("mnozstvi", ammount);


            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<KART>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<KART> td2 = new List<KART>();
                td2.Add(new KART { description = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<DOS> getByID(int id)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "id"); // replaces matching token in request.Resource
            request.AddParameter("id", id); // adds to POST or URL querystring based on Method

            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<DOS>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<DOS> td2 = new List<DOS>();
                td2.Add(new DOS { description = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<DOS> postWrite(string description, string name, int category, int price)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "write"); // replaces matching token in request.Resource
            request.AddParameter("name", name); // adds to POST or URL querystring based on Method
            request.AddParameter("description", description); // adds to POST or URL querystring based on Method
            request.AddParameter("category_id", category); // adds to POST or URL querystring based on Method
            request.AddParameter("price", price); // adds to POST or URL querystring based on Method

            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<DOS>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<DOS> td2 = new List<DOS>();
                td2.Add(new DOS { description = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<DOS> postUpdate(string description, string name, int category, int price, int id)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "update"); // replaces matching token in request.Resource
            request.AddParameter("id", id);
            request.AddParameter("name", name); // adds to POST or URL querystring based on Method
            request.AddParameter("description", description); // adds to POST or URL querystring based on Method
            request.AddParameter("category_id", category); // adds to POST or URL querystring based on Method
            request.AddParameter("price", price); // adds to POST or URL querystring based on Method

            // execute the request
            IRestResponse response = client.Execute(request);
            try
            {
                var content = response.Content.FromJson<List<DOS>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<DOS> td2 = new List<DOS>();
                td2.Add(new DOS { description = "error message: " + ex.Message });
                return td2;
            }
        }

        public List<DOS> postDelete(int ID)
        {
            var client = new RestClient("https://student.sps-prosek.cz/~sevcima14/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("api2/", Method.POST);
            request.AddParameter("action", "delete"); // replaces matching token in request.Resource
            request.AddParameter("id", ID); // adds to POST or URL querystring based on Method


            // execute the request
            IRestResponse response = client.Execute(request);

            try
            {
                var content = response.Content.FromJson<List<DOS>>(); // raw content as string
                return content;
            }
            catch (System.Net.WebException ex)
            {
                List<DOS> td2 = new List<DOS>();
                td2.Add(new DOS { description = "error message: " + ex.Message });
                return td2;
            }
        }
    }
}
