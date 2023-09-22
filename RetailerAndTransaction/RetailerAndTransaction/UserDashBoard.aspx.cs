using RetailerAndTransaction.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace RetailerAndTransaction
{
    public partial class UserDashBoard : System.Web.UI.Page
    {
        public string customerId = "";
        static HttpClient client = new HttpClient();
        static bool errorFound = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Main.isLoggedIn==false)
            {
                Response.Redirect("LoginPage.aspx", false);
            }
            if (!Page.IsPostBack)
            {
            }
        }

        public async void SearchTextChangeHandler(Object sender, EventArgs e)
        {

            string text = txtSearch.Text.Trim();
            if (text != "")
            {
                string url = "https://localhost:7134/api/Customer/GetCustomerByNid/"+text;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    CustomerResponse data = response.Content.ReadAsAsync<CustomerResponse>().Result;
                    txtName.Text = data.results[0].CustomerName;
                    drpgender.Text = "";
                    if (data.results[0].CustomerGender=="F")
                    {
                        drpgender.Text = "Female";
                    }
                    else if (data.results[0].CustomerGender=="M")
                    {
                        drpgender.Text = "Male";
                    }
                    else
                    {
                        drpgender.Text = "Other";
                    }
                    txtFathersName.Text = data.results[0].CustomerFatherName;
                    txtMothersName.Text = data.results[0].CustomerMotherName;
                    txtNid.Text = data.results[0].Nid;

                    char[] spearator = { ' ' };
                    Int32 count = 3;
                    txtDob.Text = data.results[0].Dob.ToString().Split(spearator, count, StringSplitOptions.None)[0];

                    drpReligion.Text = "";
                    if (data.results[0].Religion=="101")
                    {
                        drpReligion.Text = "Muslim";
                    }
                    else if (data.results[0].Religion=="102")
                    {
                        drpReligion.Text = "Hinduism";
                    }
                    else if (data.results[0].Religion=="103")
                    {
                        drpReligion.Text = "Chrishtian";
                    }
                    else
                    {
                        drpReligion.Text = "Buddhism";
                    }

                    drpOccupation.Text = "";
                    if (data.results[0].Occupation=="201")
                    {
                        drpOccupation.Text = "Service Holder";
                    }
                    else if (data.results[0].Occupation=="202")
                    {
                        drpOccupation.Text = "Business";
                    }
                    else
                    {
                        drpOccupation.Text = "House Maker";
                    }
                    txtMonthlyIncome.Text = data.results[0].MonthlyIncome.ToString();
                    txtPhoneNo.Text = data.results[0].PhoneNo;
                    txtPerAdd.Text = data.results[0].PerAddress;
                    drpPerDivision.Text = data.results[0].PerDivision;
                    drpPerDistrict.Text = data.results[0].PerDistrict;
                    txtPerThana.Text = data.results[0].PerThana;
                    txtPerPostCode.Text = data.results[0].PerPostalCode;
                    txtPreAdd.Text = data.results[0].PreAddress;
                    drpPreDivision.Text = data.results[0].PreDivision;
                    drpPreDistrict.Text = data.results[0].PreDistrict;
                    txtPreThana.Text = data.results[0].PreThana;
                    txtPrePostalCode.Text = data.results[0].PrePostalCode;
                    txtComAdd.Text = data.results[0].ComAddress;
                    drpComDivision.Text = data.results[0].ComDivision;
                    drpComDistrict.Text = data.results[0].ComDistrict;
                    txtComThana.Text = data.results[0].ComThana;
                    txtComPostalCode.Text = data.results[0].ComPostalCode;
                    drpCusOpenBy.Text = data.results[0].EmployeeId;
                }
                else
                {
                    txtName.Text = "";
                    drpgender.Text = "";
                    txtFathersName.Text = "";
                    txtMothersName.Text = "";
                    txtNid.Text = "";
                    txtDob.Text = "";
                    drpReligion.Text = "";
                    drpOccupation.Text = "";
                    txtMonthlyIncome.Text = "";
                    txtPhoneNo.Text = "";
                    txtPerAdd.Text = "";
                    drpPerDivision.Text = "";
                    drpPerDistrict.Text = "";
                    txtPerThana.Text = "";
                    txtPerPostCode.Text = "";
                    txtPreAdd.Text = "";
                    drpPreDivision.Text = "";
                    drpPreDistrict.Text = "";
                    txtPreThana.Text = "";
                    txtPrePostalCode.Text = "";
                    txtComAdd.Text = "";
                    drpComDivision.Text = "";
                    drpComDistrict.Text = "";
                    txtComThana.Text = "";
                    txtComPostalCode.Text = "";
                    drpCusOpenBy.Text = "";
                }
            }
            else
            {

                if (text == "")
                {
                    txtSearchError.Text = "*Can not be empty!";
                }
            }
        }
        public async void getAllAccounts(string customerId)
        {
            string url = "https://localhost:7134/api/Account/Customer/"+customerId;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<Account> accounts = response.Content.ReadAsAsync<List<Account>>().Result;
                GridView1.DataSource = accounts;
                GridView1.DataBind();
            }
        }

        public async void getCustomerID(string customerNidOrPhone)
        {

            string url = "https://localhost:7134/api/Customer/GetCustomerByNid/"+customerNidOrPhone;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {

                Response.Write("API Call Success");
                CustomerResponse res = response.Content.ReadAsAsync<CustomerResponse>().Result;
                if (res.results.ToArray()[0].CustomerId!="")
                {
                    getAllAccounts(res.results.ToArray()[0].CustomerId);
                }
                else
                {
                    DataTable ds = new DataTable();
                    ds = null;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                }
            }
            else
            {

                Response.Write("API Call Failed");
                DataTable ds = new DataTable();
                ds = null;
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        public void SearchButtonClickHandler(Object sender, EventArgs e)
        {
            errorFound=false;

            //search NID error
            string text = txtSearch.Text.Trim();
            txtSearchError.Text = "";
            if (text == "")
            {
                txtSearchError.Text = "*Can not be empty!";
                errorFound = true;
            }

            string customerNidOrPhone = txtSearch.Text.Trim();
            if (customerNidOrPhone!="")
            {
                //Response.Write(customerNidOrPhone); 
                getCustomerID(customerNidOrPhone);
            }
        }

        public void OnClickLogOut(object sender, EventArgs e)
        {
            Main.isLoggedIn = false;
            Response.Redirect("LoginPage.aspx", false);
        }
    }
}