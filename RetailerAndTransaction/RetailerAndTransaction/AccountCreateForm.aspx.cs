using RetailerAndTransaction.models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.UI;



namespace RetailerAndTransaction
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        static bool errorFound = false;
        static bool dataFound = false;        

        protected void drpProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SelectedValue"] = drpProductType.SelectedValue;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Main.isLoggedIn==false)
            {
                Response.Redirect("LoginPage.aspx", false);
            }
            if (!IsPostBack)
            {
                getAllEmployees();
                getAllProducts();
                if (Session["SelectedValue"] != null)
                {
                    drpProductType.SelectedValue = Session["SelectedValue"].ToString();
                }
            }
        }

        public async void getAllProducts()
        {
            string url = "https://localhost:7134/api/Product";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode )
            {
                List<AccountProduct> products = response.Content.ReadAsAsync<List<AccountProduct>>().Result;
                drpProductType.Items.Clear();
                drpProductType.Items.Add("Select");
                for (int i = 0; i<products.Count; i++)
                {
                    drpProductType.Items.Add(products[i].ProductName);
                }
            }
        }

        public async void getSubProductsByProductType(string productType)
        {
            string url = "https://localhost:7134/api/SubProduct/"+productType;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<SubProduct> subProducts = response.Content.ReadAsAsync<List<SubProduct>>().Result;
                drpSubProduct.Items.Clear();
                drpSubProduct.Items.Add("Select");
                for (int i = 0; i<subProducts.Count; i++)
                {
                    drpSubProduct.Items.Add(subProducts[i].SubProductName+"-"+subProducts[i].SubProductType);
                }
            }
        }

        public async void getAllEmployees()
        {
            string url = "https://localhost:7134/api/EmployeeInfo";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<Employee> employees = response.Content.ReadAsAsync<List<Employee>>().Result;
                drpAccOpenBy.Items.Clear();
                drpAccOpenBy.Items.Add("Select");
                for (int i = 0; i<employees.Count; i++)
                {
                    drpAccOpenBy.Items.Add(employees[i].EmployeeName);
                    //drpAccOpenBy.Items.Add(employees[i].EmployeeId+" - "+employees[i].EmployeeName);
                }
            }
        }
        /*
        public async void customerIdChangehandler(object sender, EventArgs e)
        {
            string text = txtCustomerId.Text.Trim();
            txtCustomerIdError.Text = "";
            errorFound = false;
            if (text == "")
            {
                errorFound = true;
            }
            if (!errorFound)
            {
                string url = "https://localhost:7134/api/Customer/GetMatchedCustomersByCustomerId/"+text;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    CustomerResponse data = response.Content.ReadAsAsync<CustomerResponse>().Result;
                    Response.Write(data.results);
                    DropDownList1.Items.Clear();
                    DropDownList1.Items.Add("Select");
                    for (int i = 0; i<data.results.Count; i++)
                    {
                        DropDownList1.Items.Add(data.results[i].CustomerId);
                    }
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
        }
        */
        public void productTypeChangehandler(object sender, EventArgs e)
        {
            drpProductTypeError.Text = "";
            errorFound= false;
            if (drpProductType.Text == "0" || drpProductType.Text == "Select")
            {
                drpProductTypeError.Text = "*Can not be empty!";
                errorFound=true;
            }
            else
            {
                string text = drpProductType.Text;
                char[] spearator = { '-' };
                Int32 count = 2;
                string productType = text.Split(spearator, count, StringSplitOptions.None)[1];
                if (productType!="")
                {
                    getSubProductsByProductType(productType);
                }
            }
        }

        public async void txtIdChangehandler(object sender, EventArgs e)
        {
            string text = txtCustomerId.Text.Trim();
            if (text.Trim() != "")
            {
                txtCustomerIdError.Text = "";
                string url = "https://localhost:7134/api/Customer/GetCustomerByCustomerId/"+text;
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
                    dataFound = true;
                }
                else
                {
                    dataFound = false;
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
                    txtCustomerIdError.Text = "*Can not be empty!";
                }
            }
            
        }
        public void branchCodeChangehandler(object sender, EventArgs e)
        {
            drpBranchCodeError.Text = "";
            errorFound= false;
            if (drpBranchCode.Text == "0" || drpBranchCode.Text == "Choose")
            {
                drpBranchCodeError.Text = "*Can not be empty!";
                errorFound=true;
            }
        }

        public void subProductChangehandler(object sender, EventArgs e)
        {
            drpSubProductError.Text = "";
            errorFound= false;
            if (drpSubProduct.Text == "0" || drpSubProduct.Text == "Select")
            {
                drpSubProductError.Text = "*Can not be empty!";
                errorFound=true;
            }
        }

        public void accOpenByChangehandler(object sender, EventArgs e)
        {
            drpAccOpenByError.Text = "";
            errorFound= false;
            if (drpAccOpenBy.Text == "0" || drpAccOpenBy.Text == "Select")
            {
                drpAccOpenByError.Text = "*Can not be empty!";
                errorFound=true;
            }
        }

        public void SaveButton_ClickHandler(object sender, EventArgs e)
        {
            errorFound=false;


            //customerid error
            string text = txtCustomerId.Text.Trim();
            txtCustomerIdError.Text = "";
            if (text == "")
            {
                txtCustomerIdError.Text = "*Can not be empty!";
                errorFound = true;
            }


            //productType Error
            drpProductTypeError.Text = "";
            if (drpProductType.Text == "0" || drpProductType.Text == "Select")
            {
                drpProductTypeError.Text = "*Can not be empty!";
                errorFound=true;
            }

            //Branch error
            drpBranchCodeError.Text = "";
            errorFound= false;
            if (drpBranchCode.Text == "0" || drpBranchCode.Text == "Choose")
            {
                drpBranchCodeError.Text = "*Can not be empty!";
                errorFound=true;
            }

            //SubProduct
            drpSubProductError.Text = "";
            errorFound= false;
            if (drpSubProduct.Text == "0" || drpSubProduct.Text == "Select")
            {
                drpSubProductError.Text = "*Can not be empty!";
                errorFound=true;
            }

            //Account open by
            drpAccOpenByError.Text = "";
            errorFound= false;
            if (drpAccOpenBy.Text == "0" || drpAccOpenBy.Text == "Select")
            {
                drpAccOpenByError.Text = "*Can not be empty!";
                errorFound=true;
            }

            if (!errorFound && dataFound)
            {
                char[] spearator = { '-' };
                Int32 count = 2;
                string productType = drpProductType.Text.Split(spearator, count, StringSplitOptions.None)[1];
                string subProductType = drpSubProduct.Text.Split(spearator, count, StringSplitOptions.None)[1];
                Account account = new Account(0, "", txtCustomerId.Text, productType, 0, DateTime.Now, "Active", drpBranchCode.Text, drpAccOpenBy.Text, subProductType);
                string url = "https://localhost:7134/api/Account";
                var response = client.PostAsJsonAsync(url, account).Result;
                if (response.IsSuccessStatusCode)
                {
                    AccountResponse data = response.Content.ReadAsAsync<AccountResponse>().Result;
                    Response.Write("Account Created. Account No : "+data.account_no);
                }
                else
                {
                    Page.Response.Write("Account creation error");
                }
            }
        }

        public void OnClickLogOut(object sender, EventArgs e)
        {
            Main.isLoggedIn = false;    
            Response.Redirect("LoginPage.aspx", false);
        }
    }
}