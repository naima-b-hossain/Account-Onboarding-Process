using RetailerAndTransaction.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RetailerAndTransaction
{
    public partial class Login : System.Web.UI.Page
    {

        static HttpClient client = new HttpClient();
        static bool errorFound = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Main.isLoggedIn)
            {
                Response.Redirect("UserDashBoard.aspx", false);
            }
        }

        public void LoginButtonClickHandler(Object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (email!="" && password!="")
            {
                User userInputDate = new User(0, email, password, "");
                
                string url = "https://localhost:7134/api/Login";
                var response = client.PostAsJsonAsync(url, userInputDate).Result;
                if (response.IsSuccessStatusCode)
                {
                    //var data = response.Content.ReadAsStringAsync().Result;
                    Main.isLoggedIn = true; 
                    Response.Redirect("UserDashBoard.aspx", false);
                }
                else
                {
                    //var data = response.Content.ReadAsStringAsync().Result;
                    Response.Write("Login Failed");
                }
                
            }
        }

    }
}