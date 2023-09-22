using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using RetailerAndTransaction.models;
using System.Text.RegularExpressions;

namespace RetailerAndTransaction
{
    partial class WebForm1 : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        static bool errorFound = false;
        string[] districts = {
            "Choose",


            "Barguna",
            "Barisal",
            "Bhola",
            "Jhalokati",
            "Patuakhali",
            "Pirojpur",


            "Bandarban",
            "Brahmanbaria",
            "Chandpur",
            "Chittagong",
            "Comilla",
            "Cox's Bazar",
            "Feni",
            "Khagrachhari",
            "Lakshmipur",
            "Noakhali",
            "Rangamati",


            "Dhaka",
            "Faridpur",
            "Gazipur",
            "Gopalganj",
            "Jamalpur",
            "Kishoreganj",
            "Madaripur",
            "Manikganj",
            "Munshiganj",
            "Mymensingh",
            "Narayanganj",
            "Narsingdi",
            "Netrokona",
            "Rajbari",
            "Shariatpur",
            "Sherpur",
            "Tangail",


            "Bagerhat",
            "Chuadanga",
            "Jessore",
            "Jhenaidaha",
            "Khulna",
            "Kushtia",
            "Magura",
            "Meherpur",
            "Narail",
            "Satkhira",


            "Bogra",
            "Joypurhat",
            "Naogaon",
            "Natore",
            "Nawabganj",
            "Pabna",
            "Rajshahi",
            "Sirajganj",


            "Dinajpur",
            "Gaibandha",
            "Kurigram",
            "Lalmonirhat",
            "Nilphamari",
            "Panchagarh",
            "Rangpur",
            "Thakurgaon",


            "Habiganj",
            "Maulvi Bazar",
            "Sunamganj",
            "Sylhet"
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Main.isLoggedIn==false)
            {
                Response.Redirect("LoginPage.aspx", false);
            }
            if (!this.Page.IsPostBack)
            {
                getAllEmployees();
                getAllDivisions();
            }
        }

        public async void getAllEmployees()
        {
            string url = "https://localhost:7134/api/EmployeeInfo";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<Employee> employees = response.Content.ReadAsAsync<List<Employee>>().Result;
                drpCusOpenBy.Items.Clear();
                drpCusOpenBy.Items.Add("Select");
                for (int i = 0; i<employees.Count; i++)
                {
                    drpCusOpenBy.Items.Add(employees[i].EmployeeName);
                }
            }
        }

        public async void getAllDivisions()
        {
            string url = "https://localhost:7134/api/Division";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                List<Division> divisions = response.Content.ReadAsAsync<List<Division>>().Result;
                drpPerDivision.Items.Clear();
                drpPerDivision.Items.Add("Select");

                drpPreDivision.Items.Clear();
                drpPreDivision.Items.Add("Select");

                drpComDivision.Items.Clear();
                drpComDivision.Items.Add("Select");

                for (int i = 0; i<divisions.Count; i++)
                {
                    drpPerDivision.Items.Add(divisions[i].DivisionName);
                    drpPreDivision.Items.Add(divisions[i].DivisionName);
                    drpComDivision.Items.Add(divisions[i].DivisionName);
                }

            }
        }

        public void nameChangehandler(object sender, EventArgs e)
        {
            int index = 0;
            string text = txtName.Text.Trim();
            txtNameError.Text = "";
            errorFound = false;
            if (text=="")
            {
                txtNameError.Text = "*Can not be empty!";
                errorFound = true;
            }

            for (int i = 0; i<text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    index++;
                }
            }
            if (index==0)
            {
                if (txtNameError.Text!="")
                {
                    txtNameError.Text += "<br/>";
                }
                txtNameError.Text += "*At least 2 words!";
                errorFound = true;
            }
        }

        public void genderChangehandler(object sender, EventArgs e)
        {
            drpgenderError.Text = "";
            errorFound= false;
            if (drpgender.Text == "0")
            {
                drpgenderError.Text = "*Can not be empty!";
                errorFound=true;
            }
        }

        public void txtFathersNameChangehandler(object sender, EventArgs e)
        {

            int index = 0;
            string text = txtFathersName.Text.Trim();
            txtFathersNameError.Text = "";
            errorFound = false;

            if (text=="")
            {
                txtFathersNameError.Text = "*Can not be empty!";
                errorFound = true;
            }

            for (int i = 0; i<text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    index++;
                }
            }
            if (index==0)
            {
                if (txtFathersNameError.Text!="")
                {
                    txtFathersNameError.Text += "<br/>";
                }
                txtFathersNameError.Text += "*At least 2 words!";
                errorFound = true;
            }
        }

        public void txtMothersNameChangehandler(object sender, EventArgs e)
        {

            int index = 0;
            string text = txtMothersName.Text.Trim();
            txtMothersNameError.Text = "";
            errorFound = false;

            if (text=="")
            {
                txtMothersNameError.Text = "*Can not be empty!";
                errorFound = true;
            }

            for (int i = 0; i<text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    index++;
                }
            }
            if (index==0)
            {
                if (txtMothersNameError.Text!="")
                {
                    txtMothersNameError.Text += "<br/>";
                }
                txtMothersNameError.Text += "*At least 2 words!";
                errorFound = true;
            }
        }
        public void txtNidChangehandler(object sender, EventArgs e)
        {
            string text = txtNid.Text.Trim();
            txtNidError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtNidError.Text = "*Can not be empty!";
            }
            if (text.Length!=17)
            {
                if (txtNidError.Text=="")
                {
                    txtNidError.Text = "<br/>";
                }
                txtNidError.Text = "*Must be 17 digits";
            }
        }
        public void religionChangehandler(object sender, EventArgs e)
        {
            drpReligionError.Text = "";
            errorFound= false;
            if (drpReligion.Text == "0")
            {
                drpReligionError.Text = "*Can not be empty!";
                errorFound=true;
            }
        }

        public void occupationChangehandler(object sender, EventArgs e)
        {
            drpOccupationError.Text = "";
            errorFound= false;
            if (drpOccupation.Text == "0")
            {
                drpOccupationError.Text = "*Can not be empty!";
                errorFound=true;
            }
        }


        public void txtMonthlyIncomeChangehandler(object sender, EventArgs e)
        {
            string text = txtMonthlyIncome.Text.Trim();
            txtMonthlyIncomeError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtMonthlyIncomeError.Text = "*Can not be empty!";
                errorFound = true;
                return;
            }
            for (int i = 0; i<text.Length; i++)
            {
                if (!char.IsNumber(text[i]))
                {
                    txtMonthlyIncomeError.Text = "*Must be number!";
                    errorFound = true;
                    return;
                }
            }
            if (Int32.Parse(text)<10000)
            {
                txtMonthlyIncomeError.Text = "*Must be greater than 10,000tk!";
                errorFound = true;
            }
        }

        public void txtPhoneNoChangehandler(object sender, EventArgs e)
        {
            string text = txtPhoneNo.Text.Trim();
            txtPhoneNoError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtPhoneNoError.Text = "*Can not be empty!";
                errorFound = true;
                return;
            }
            string strRegex = @"(\+880[0-9]{10}|880[0-9]{10}|^[0-9]{11}$)";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(text))
            {
                txtPhoneNoError.Text = "*Wrong Format (+88017******** | 017********)";
                errorFound = true;
            }
        }

        public void txtPerAddChangehandler(object sender, EventArgs e)
        {
            string text = txtPerAdd.Text.Trim();
            txtPerAddError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtPerAddError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public async void drpPerDivisionChangehandler(object sender, EventArgs e)
        {
            string text = drpPerDivision.Text.Trim();
            if (text == "0" || text == "Select")
            {
                drpPerDistrict.Items.Clear();
                drpPerDistrictError.Text = "";
                drpPerDistrict.Items.Add(new ListItem("Select Permanent Division"));
                drpPerDivisionError.Text = "*Can not be empty!";
            }
            string divisionType = null;
            if (text=="Barishal")
            {
                divisionType = "001";
            }
            if (text=="Chittagong")
            {
                divisionType = "002";
            }
            if (text=="Dhaka")
            {
                divisionType = "003";
            }
            if (text=="Khulna")
            {
                divisionType = "004";
            }
            if (text=="Rangpur")
            {
                divisionType = "005";
            }
            if (text=="Rajshahi")
            {
                divisionType = "006";
            }
            if (text=="Sylhet")
            {
                divisionType = "007";
            }
            if (divisionType!=null)
            {
                string url = "https://localhost:7134/api/District/"+divisionType;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<District> districts = response.Content.ReadAsAsync<List<District>>().Result;
                    drpPerDistrict.Items.Clear();
                    drpPerDistrict.Items.Add("Select");
                    for (int i = 0; i<districts.Count; i++)
                    {
                        drpPerDistrict.Items.Add(districts[i].DistrictName);
                    }
                }
            }

        }


        public async void drpPerDistrictChangehandler(object sender, EventArgs e)
        {
            string text = drpPerDistrict.Text.Trim();
            if (text == "0" || text=="Select")
            {
                drpPerThana.Items.Clear();
                drpPerThanaError.Text = "";
                drpPerThana.Items.Add(new ListItem("Select Permanent District"));
                drpPerDistrictError.Text = "*Can not be empty!";
                return;
            }
            string districtType = null;
            if (text=="Barguna")
            {
                districtType = "0001";
            }
            if (text=="Barisal")
            {
                districtType = "0002";
            }
            if (text=="Bhola")
            {
                districtType = "0003";
            }
            if (text=="Jhalokati")
            {
                districtType = "0004";
            }
            if (text=="Patuakhali")
            {
                districtType = "0005";
            }
            if (text=="Pirojpur")
            {
                districtType = "0006";
            }
            if (text=="Bandarban")
            {
                districtType = "0007";
            }
            if (text=="Brahmanbaria")
            {
                districtType = "0008";
            }
            if (text=="Chandpur")
            {
                districtType = "0009";
            }
            if (text=="Chittagong")
            {
                districtType = "0010";
            }
            if (text=="Comilla")
            {
                districtType = "0011";
            }
            if (text=="Cox's Bazar")
            {
                districtType = "0012";
            }
            if (text=="Feni")
            {
                districtType = "0013";
            }
            if (text=="Khagrachhari")
            {
                districtType = "0014";
            }
            if (text=="Lakshmipur")
            {
                districtType = "0015";
            }
            if (text=="Noakhali")
            {
                districtType = "0016";
            }
            if (text=="Rangamati")
            {
                districtType = "0017";
            }
            if (text=="Dhaka")
            {
                districtType = "0018";
            }
            if (districtType!=null)
            {
                string url = "https://localhost:7134/api/Thana/"+districtType;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<Thana> thana = response.Content.ReadAsAsync<List<Thana>>().Result;
                    drpPerThana.Items.Clear();
                    drpPerThana.Items.Add("Select");
                    for (int i = 0; i<thana.Count; i++)
                    {
                        drpPerThana.Items.Add(thana[i].ThanaName);
                    }
                }
            }
        }


        public void drpPerThanaChangehandler(object sender, EventArgs e)
        {
            string text = drpPerThana.Text.Trim();
            drpPerThanaError.Text = "";
            if (text == "0" || text == "Select")
            {
                drpPerThanaError.Text = "*Can not be empty!";
            }
        }

        public void txtPerPostCodeChangehandler(object sender, EventArgs e)
        {
            string text = txtPerPostCode.Text.Trim();
            txtPerPostCodeError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtPerPostCodeError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public void txtPreAddChangehandler(object sender, EventArgs e)
        {
            string text = txtPreAdd.Text.Trim();
            txtPreAddError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtPreAddError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }
        public async void drpPreDivisionChangehandler(object sender, EventArgs e)
        {
            string text = drpPreDivision.Text.Trim();
            drpPreDivisionError.Text = "";
            if (text == "0" || text=="Select")
            {
                drpPreDistrict.Items.Clear();
                drpPreDistrictError.Text = "";
                drpPreDistrict.Items.Add(new ListItem("Select Present Divission"));
                drpPreDivisionError.Text = "*Can not be empty!";
                return;
            }

            string divisionType = null;
            if (text=="Barishal")
            {
                divisionType = "001";
            }
            if (text=="Chittagong")
            {
                divisionType = "002";
            }
            if (text=="Dhaka")
            {
                divisionType = "003";
            }
            if (text=="Khulna")
            {
                divisionType = "004";
            }
            if (text=="Rangpur")
            {
                divisionType = "005";
            }
            if (text=="Rajshahi")
            {
                divisionType = "006";
            }
            if (text=="Sylhet")
            {
                divisionType = "007";
            }
            if (divisionType!=null)
            {
                string url = "https://localhost:7134/api/District/"+divisionType;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<District> districts = response.Content.ReadAsAsync<List<District>>().Result;
                    drpPreDistrict.Items.Clear();
                    drpPreDistrict.Items.Add("Select");
                    for (int i = 0; i<districts.Count; i++)
                    {
                        drpPreDistrict.Items.Add(districts[i].DistrictName);
                    }
                }
            }

        }


        public async void drpPreDistrictChangehandler(object sender, EventArgs e)
        {
            string text = drpPreDistrict.Text.Trim();
            if (text == "0" || text == "Select")
            {
                drpPreThana.Items.Clear();
                drpPreThanaError.Text = "";
                drpPreThana.Items.Add(new ListItem("Select Permanent District"));
                drpPreDistrictError.Text = "*Can not be empty!";
                return;
            }
            string districtType = null;
            if (text=="Barguna")
            {
                districtType = "0001";
            }
            if (text=="Barisal")
            {
                districtType = "0002";
            }
            if (text=="Bhola")
            {
                districtType = "0003";
            }
            if (text=="Jhalokati")
            {
                districtType = "0004";
            }
            if (text=="Patuakhali")
            {
                districtType = "0005";
            }
            if (text=="Pirojpur")
            {
                districtType = "0006";
            }
            if (text=="Bandarban")
            {
                districtType = "0007";
            }
            if (text=="Brahmanbaria")
            {
                districtType = "0008";
            }
            if (text=="Chandpur")
            {
                districtType = "0009";
            }
            if (text=="Chittagong")
            {
                districtType = "0010";
            }
            if (text=="Comilla")
            {
                districtType = "0011";
            }
            if (text=="Cox's Bazar")
            {
                districtType = "0012";
            }
            if (text=="Feni")
            {
                districtType = "0013";
            }
            if (text=="Khagrachhari")
            {
                districtType = "0014";
            }
            if (text=="Lakshmipur")
            {
                districtType = "0015";
            }
            if (text=="Noakhali")
            {
                districtType = "0016";
            }
            if (text=="Rangamati")
            {
                districtType = "0017";
            }
            if (text=="Dhaka")
            {
                districtType = "0018";
            }
            if (districtType!=null)
            {
                string url = "https://localhost:7134/api/Thana/"+districtType;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<Thana> thana = response.Content.ReadAsAsync<List<Thana>>().Result;
                    drpPreThana.Items.Clear();
                    drpPreThana.Items.Add("Select");
                    for (int i = 0; i<thana.Count; i++)
                    {
                        drpPreThana.Items.Add(thana[i].ThanaName);
                    }
                }
            }
        }

        public void drpPreThanaChangehandler(object sender, EventArgs e)
        {
            string text = drpPreThana.Text.Trim();
            drpPreThanaError.Text = "";
            if (text == "0" || text == "Select")
            {
                drpPreThanaError.Text = "*Can not be empty!";
            }

        }

        public void txtPrePostalCodeChangehandler(object sender, EventArgs e)
        {
            string text = txtPrePostalCode.Text.Trim();
            txtPrePostalCodeError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtPrePostalCodeError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public void txtComAddChangehandler(object sender, EventArgs e)
        {
            string text = txtComAdd.Text.Trim();
            txtComAddError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtComAddError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public async void drpComDivisionChangehandler(object sender, EventArgs e)
        {
            string text = drpComDivision.Text.Trim();
            drpComDivisionError.Text = "";
            if (text == "0" || text=="Select")
            {
                drpComDistrict.Items.Clear();
                drpComDistrictError.Text = "";
                drpComDistrict.Items.Add(new ListItem("Select Communication Divission"));
                drpComDivisionError.Text = "*Can not be empty!";
                return;
            }
            string divisionType = null;
            if (text=="Barishal")
            {
                divisionType = "001";
            }
            if (text=="Chittagong")
            {
                divisionType = "002";
            }
            if (text=="Dhaka")
            {
                divisionType = "003";
            }
            if (text=="Khulna")
            {
                divisionType = "004";
            }
            if (text=="Rangpur")
            {
                divisionType = "005";
            }
            if (text=="Rajshahi")
            {
                divisionType = "006";
            }
            if (text=="Sylhet")
            {
                divisionType = "007";
            }
            if (divisionType!=null)
            {
                string url = "https://localhost:7134/api/District/"+divisionType;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<District> districts = response.Content.ReadAsAsync<List<District>>().Result;
                    drpComDistrict.Items.Clear();
                    drpComDistrict.Items.Add("Select");
                    for (int i = 0; i<districts.Count; i++)
                    {
                        drpComDistrict.Items.Add(districts[i].DistrictName);
                    }
                }
            }



        }

        public async void drpComDistrictChangehandler(object sender, EventArgs e)
        {
            string text = drpComDistrict.Text.Trim();
            if (text == "0" || text=="Select")
            {
                drpComThana.Items.Clear();
                drpComThanaError.Text = "";
                drpComThana.Items.Add(new ListItem("Select Permanent District"));
                drpComDistrictError.Text = "*Can not be empty!";
                return;
            }
            string districtType = null;
            if (text=="Barguna")
            {
                districtType = "0001";
            }
            if (text=="Barisal")
            {
                districtType = "0002";
            }
            if (text=="Bhola")
            {
                districtType = "0003";
            }
            if (text=="Jhalokati")
            {
                districtType = "0004";
            }
            if (text=="Patuakhali")
            {
                districtType = "0005";
            }
            if (text=="Pirojpur")
            {
                districtType = "0006";
            }
            if (text=="Bandarban")
            {
                districtType = "0007";
            }
            if (text=="Brahmanbaria")
            {
                districtType = "0008";
            }
            if (text=="Chandpur")
            {
                districtType = "0009";
            }
            if (text=="Chittagong")
            {
                districtType = "0010";
            }
            if (text=="Comilla")
            {
                districtType = "0011";
            }
            if (text=="Cox's Bazar")
            {
                districtType = "0012";
            }
            if (text=="Feni")
            {
                districtType = "0013";
            }
            if (text=="Khagrachhari")
            {
                districtType = "0014";
            }
            if (text=="Lakshmipur")
            {
                districtType = "0015";
            }
            if (text=="Noakhali")
            {
                districtType = "0016";
            }
            if (text=="Rangamati")
            {
                districtType = "0017";
            }
            if (text=="Dhaka")
            {
                districtType = "0018";
            }
            if (districtType!=null)
            {
                string url = "https://localhost:7134/api/Thana/"+districtType;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<Thana> thana = response.Content.ReadAsAsync<List<Thana>>().Result;
                    drpComThana.Items.Clear();
                    drpComThana.Items.Add("Select");
                    for (int i = 0; i<thana.Count; i++)
                    {
                        drpComThana.Items.Add(thana[i].ThanaName);
                    }
                }
            }
        }

        public void drpComThanaChangehandler(object sender, EventArgs e)
        {
            string text = drpComThana.Text.Trim();
            drpComThanaError.Text = "";
            if (text == "0" || text == "Select")
            {
                drpComThanaError.Text = "*Can not be empty!";
            }

        }

        public void txtComPostalCodeChangehandler(object sender, EventArgs e)
        {
            string text = txtComPostalCode.Text.Trim();
            txtComPostalCodeError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtComPostalCodeError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public void drpCusOpenByChangehandler(object sender, EventArgs e)
        {
            drpCusOpenByError.Text = "";
            if (drpCusOpenBy.Text == "0" || drpCusOpenBy.Text == "Select")
            {
                drpCusOpenByError.Text = "*Can not be empty!";
            }
        }

        public void txtDobChangehandler(object sender, EventArgs e) {
            
            if ((string)txtDob.Text == "")
            {
                txtDobError.Text ="*Can not be empty!";
            }
            else
            {
                txtDobError.Text = "";
            }
        }

        public void SaveButtonClickHandler(Object sender, EventArgs e)
        {
            bool errorFoundOnClickSave =false;

            // check name error
            int index = 0;
            string text = txtName.Text.Trim();
            txtNameError.Text = "";
            if (text=="")
            {
                txtNameError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }

            for (int i = 0; i<text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    index++;
                }
            }
            if (index==0)
            {
                if (txtNameError.Text!="")
                {
                    txtNameError.Text += "<br/>";
                }
                txtNameError.Text += "*At least 2 words!";
                errorFoundOnClickSave = true;
            }

            // check gender error
            drpgenderError.Text = "";
            if (drpgender.Text == "0")
            {
                drpgenderError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check fathers name error
            index = 0;
            text = txtFathersName.Text.Trim();
            txtFathersNameError.Text = "";

            if (text=="")
            {
                txtFathersNameError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }

            for (int i = 0; i<text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    index++;
                }
            }
            if (index==0)
            {
                if (txtFathersNameError.Text!="")
                {
                    txtFathersNameError.Text += "<br/>";
                }
                txtFathersNameError.Text += "*At least 2 words!";
                errorFoundOnClickSave = true;
            }

            // check mothers name error
            index = 0;
            text = txtMothersName.Text.Trim();
            txtMothersNameError.Text = "";

            if (text=="")
            {
                txtMothersNameError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }

            for (int i = 0; i<text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i]))
                {
                    index++;
                }
            }
            if (index==0)
            {
                if (txtMothersNameError.Text!="")
                {
                    txtMothersNameError.Text += "<br/>";
                }
                txtMothersNameError.Text += "*At least 2 words!";
                errorFoundOnClickSave = true;
            }

            // check nid error
            text = txtNid.Text.Trim();
            txtNidError.Text = "";
            if (text == "")
            {
                txtNidError.Text = "*Can not be empty!";
            }
            if (text.Length!=17)
            {
                if (txtNidError.Text=="")
                {
                    txtNidError.Text = "<br/>";
                }
                txtNidError.Text = "*Must be 17 digits";
            }

            // check religion error
            drpReligionError.Text = "";
            if (drpReligion.Text == "0")
            {
                drpReligionError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }


            // check occupation error
            drpOccupationError.Text = "";
            if (drpOccupation.Text == "0")
            {
                drpOccupationError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check monthly income error
            text = txtMonthlyIncome.Text.Trim();
            txtMonthlyIncomeError.Text = "";
            if (text == "")
            {
                txtMonthlyIncomeError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;

            }
            else
            {
                bool mustBeNumberError = false; 
                for (int i = 0; i<text.Length; i++)
                {
                    if (!char.IsNumber(text[i]))
                    {
                        txtMonthlyIncomeError.Text = "*Must be number!";
                        errorFoundOnClickSave = true;
                        mustBeNumberError = true;
                    }
                }
                if (mustBeNumberError==true && Int32.Parse(text)<10000)
                {
                    txtMonthlyIncomeError.Text = "*Must be greater than 10,000tk!";
                    errorFoundOnClickSave = true;
                }
            }
            
           

            // check phone no error
            text = txtPhoneNo.Text.Trim();
            txtPhoneNoError.Text = "";
            if (text == "")
            {
                txtPhoneNoError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }
            else
            {
                string strRegex = @"(\+880[0-9]{10}|880[0-9]{10}|^[0-9]{11}$)";
                Regex re = new Regex(strRegex);
                if (!re.IsMatch(text))
                {
                    txtPhoneNoError.Text = "*Wrong Format (+88017******** | 017********)";
                    errorFoundOnClickSave = true;
                }
            }
            

            // check permanent address error
            text = txtPerAdd.Text.Trim();
            txtPerAddError.Text = "";
            if (text == "")
            {
                txtPerAddError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }

            // check permanent division error
            text = drpPerDivision.Text.Trim();
            drpPerDivisionError.Text = "";
            if (text == "0" || text == "Select")
            {
                drpPerDistrict.Items.Clear();
                drpPerDistrictError.Text = "";
                drpPerDistrict.Items.Add(new ListItem("Select Permanent Divission"));
                drpPerDivisionError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check permanent district error
            text = drpPerDistrict.Text.Trim();
            drpPerDistrictError.Text = "";
            if (text == "0" || text == "Select Permanent Divission")
            {
                drpPerDistrictError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }


            text = drpPerThana.Text.Trim();
            drpPerThanaError.Text = "";
            if (text == "0" || text == "Select" || text == "Select Permanent Divission")
            {
                drpPerThanaError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check permanent post code error
            text = txtPerPostCode.Text.Trim();
            txtPerPostCodeError.Text = "";
            if (text == "")
            {
                txtPerPostCodeError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }

            // check present address error
            text = txtPreAdd.Text.Trim();
            txtPreAddError.Text = "";
            if (text == "")
            {
                txtPreAddError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }


            // check present division error
            text = drpPreDivision.Text.Trim();
            drpPreDivisionError.Text = "";
            if (text == "0" || text == "Select")
            {
                drpPreDistrict.Items.Clear();
                drpPreDistrictError.Text = "";
                drpPreDistrict.Items.Add(new ListItem("Select Present Divission"));
                drpPreDivisionError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check present district error
            text = drpPreDistrict.Text.Trim();
            drpPreDistrictError.Text = "";
            if (text == "0" || text == "Choose" || text=="Select Present Divission")
            {
                drpPreDistrictError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            
            text = drpPreThana.Text.Trim();
            drpPreThanaError.Text = "";
            if (text == "0" || text == "Choose")
            {
                drpPreThanaError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check present post code error
            text = txtPrePostalCode.Text.Trim();
            txtPrePostalCodeError.Text = "";
            if (text == "")
            {
                txtPrePostalCodeError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }


            // check communication address error
            text = txtComAdd.Text.Trim();
            txtComAddError.Text = "";
            if (text == "")
            {
                txtComAddError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }


            // check communication division error
            text = drpComDivision.Text.Trim();
            drpComDivisionError.Text = "";
            if (text == "0" || text == "Select")
            {
                drpComDistrict.Items.Clear();
                drpComDistrict.Items.Add(new ListItem("Select Communication Divission"));
                drpComDivisionError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check communication district error
            text = drpComDistrict.Text.Trim();
            drpComDistrictError.Text = "";
            if (text == "0" || text == "Choose" || text=="Select Communication Divission")
            {
                drpComDistrictError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check communication thana error
            text = drpComThana.Text.Trim();
            drpComThanaError.Text = "";
            if (text == "0" || text == "Choose")
            {
                drpComThanaError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check communication post code error
            text = txtComPostalCode.Text.Trim();
            txtComPostalCodeError.Text = "";
            if (text == "")
            {
                txtComPostalCodeError.Text = "*Can not be empty!";
                errorFoundOnClickSave = true;
            }

            //Customer open error
            drpCusOpenByError.Text = "";
            if (drpCusOpenBy.Text == "0" || drpCusOpenBy.Text == "Select")
            {
                drpCusOpenByError.Text = "*Can not be empty!";
                errorFoundOnClickSave=true;
            }

            // check txtDob error
            txtDobError.Text = "";
            if ((string)txtDob.Text == "")
            {
                txtDobError.Text ="*Can not be empty!";
                errorFoundOnClickSave=true;
            }


            if (errorFoundOnClickSave==false)
            {
                Customer customer = new Customer(0, "", txtName.Text, drpgender.Text, txtFathersName.Text, txtMothersName.Text, txtNid.Text, DateTime.Parse(txtDob.Text), drpReligion.Text, drpOccupation.Text, double.Parse(txtMonthlyIncome.Text), txtPhoneNo.Text, txtPerAdd.Text, drpPerDivision.Text, drpPerDistrict.Text, drpPerThana.Text, txtPerPostCode.Text, txtPreAdd.Text, drpPreDivision.Text, drpPreDistrict.Text, drpPreThana.Text, txtPrePostalCode.Text, txtComAdd.Text, drpComDivision.Text, drpComDistrict.Text, drpComThana.Text, txtComPostalCode.Text, drpCusOpenBy.Text);
                string url = "https://localhost:7134/api/Customer/CreateCustomer";
                var response = client.PostAsJsonAsync(url, customer).Result;
                if (response.IsSuccessStatusCode)
                {
                    CustomerResponse data = response.Content.ReadAsAsync<CustomerResponse>().Result;
                    Response.Write("Customer Added. New customer id is : "+data.customer_id);
                }
                else
                {
                    CustomerResponse data = response.Content.ReadAsAsync<CustomerResponse>().Result;
                    Page.Response.Write("Customer Already Exist with This NID. Exsisting customer id is : "+data.customer_id);
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