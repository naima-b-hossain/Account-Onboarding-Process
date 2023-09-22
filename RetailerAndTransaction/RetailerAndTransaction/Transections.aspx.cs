using RetailerAndTransaction.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Collections.Concurrent;
using static System.Net.Mime.MediaTypeNames;
using System.Data;

namespace RetailerAndTransaction
{
    public partial class AllTransections : System.Web.UI.Page
    {
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

        public async void getAllTransactions(string accountNo)
        {
            string url = "https://localhost:7134/api/AccTransactionInfo/Account/"+accountNo;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                gridTransaction.DataSource = null;
                gridTransaction.DataBind();
                List<AccTransactionInfo> transactions = response.Content.ReadAsAsync<List<AccTransactionInfo>>().Result;
                gridTransaction.DataSource = transactions.ToList();
                gridTransaction.DataBind();
            }
        }
        

        public void SendButtonClickHandler(Object sender, EventArgs e)
        {
            errorFound=false;


            //Sender Account error
            string accNo = txtSenderAccount.Text.Trim();
            txtSenderAccountError.Text = "";
            errorFound = false;
            if (accNo == "")
            {
                txtSenderAccountError.Text = "*Can not be empty!";
                errorFound = true;
            }

            //Receiver Account error
            string text = txtReceiverAccount.Text.Trim();
            txtReceiverAccountError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtReceiverAccountError.Text = "*Can not be empty!";
                errorFound = true;
            }


            //Transaction Amount error check
            text = txtTransferAmount.Text.Trim();
            txtTransferAmountError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtTransferAmountError.Text = "*Can not be empty!";
                errorFound = true;
            }

            //Reference error
            text = txtReference.Text.Trim();
            txtReferenceError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtReferenceError.Text = "*Can not be empty!";
                errorFound = true;
            }

            string senderAccountNo = txtSenderAccount.Text.Trim();
            string receiverAccountNo = txtReceiverAccount.Text.Trim();
            Double transferAmount = 0;
            if (txtTransferAmount.Text.Trim()!="")
            {
                transferAmount = Double.Parse(txtTransferAmount.Text.Trim());
            }

            string reference = txtReference.Text.Trim();
            if (senderAccountNo!="" && receiverAccountNo!="" && transferAmount>0 && reference!="")
            {
                MoneyTransfer moneyTransfer = new MoneyTransfer(senderAccountNo, receiverAccountNo, transferAmount, reference);
                string url = "https://localhost:7134/api/AccTransactionInfo";
                var response = client.PostAsJsonAsync(url, moneyTransfer).Result;
                if (response.IsSuccessStatusCode)
                {
                    Response.Write("Success");
                }
                else
                {
                    Response.Write("Fail");
                }
            }
        }

        public void SearchButtonClickHandler(Object sender, EventArgs e)
        {
            errorFound=false;


            //Transaction Record AccountNo error
            string text = txtAllTranAccNo.Text.Trim();
            txtAllTranAccNoError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtAllTranAccNoError.Text = "*Can not be empty!";
                errorFound = true;
            }


            string accountNo = txtAllTranAccNo.Text.Trim();
            if (accountNo!="")
            {
                getAllTransactions(accountNo);
            }
        }

        public void txtAllTranAccNoChangeHandler(object sender, EventArgs e)
        {
            string text = txtAllTranAccNo.Text.Trim();
            txtAllTranAccNoError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtAllTranAccNoError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public void SubmitButtonClickHandler(Object sender, EventArgs e)
        {
            errorFound=false;


            // AccountNo error
            string accNo = txtAccNo.Text.Trim();
            txtAccNoError.Text = "";
            errorFound = false;
            if (accNo == "")
            {
                txtAccNoError.Text = "*Can not be empty!";
                errorFound = true;
            }

            //Amount error
            string text = txtAmount.Text.Trim();
            txtAmountError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtAmountError.Text = "*Can not be empty!";
                errorFound = true;
            }

            //Type error
            drpTypeError.Text = "";
            errorFound= false;
            if (drpType.Text == "0" || drpType.Text == "Choose")
            {
                drpTypeError.Text = "*Can not be empty!";
                errorFound=true;
            }

            string customerAccountNo = txtAccNo.Text.Trim();
            double transferAmount = 0;
            if (customerAccountNo!="")
            {
                transferAmount = Double.Parse(txtAmount.Text.Trim());
            }
            string transferType = drpType.Text.Trim();
            if (customerAccountNo!="" && transferAmount>0 && transferType!="0")
            {
                MoneyTransferOwnAccount moneyTransfer = new MoneyTransferOwnAccount(customerAccountNo, transferAmount, transferType);
                string url = "https://localhost:7134/api/AccTransactionInfo/OwnAccount";
                var response = client.PostAsJsonAsync(url, moneyTransfer).Result;
                if (response.IsSuccessStatusCode)
                {
                    Response.Write("Success");
                }
                else
                {
                    Response.Write("Fail");
                }
            }
        }

        public async void txtSenderAccountChangeHandler(object sender, EventArgs e)
        {
            string accNo = txtSenderAccount.Text.Trim();
            txtSenderAccountError.Text = "";
            errorFound = false;
            if (accNo == "")
            {
                txtSenderAccountError.Text = "*Can not be empty!";
                errorFound = true;
            }
            if (accNo!="")
            {
                string url = "https://localhost:7134/api/Customer/GetCustomerByAccountNo/"+accNo;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    CustomerResponse res = response.Content.ReadAsAsync<CustomerResponse>().Result;
                    if (res.results.ToArray()[0].CustomerName!="")
                    {
                        txtSenderCustomerName.Text = res.results.ToArray()[0].CustomerName;
                        txtSenderAccountBalance.Text = res.results.ToArray()[0].AccountBalance.ToString();
                    }
                    else
                    {
                        txtSenderCustomerName.Text = "";
                        txtSenderAccountBalance.Text = "";
                    }
                }
                else
                {
                    txtSenderCustomerName.Text = "";
                    txtSenderAccountBalance.Text = "";
                }
            }
        }

        public void txtReceiverAccountChangeHandler(object sender, EventArgs e)
        {
            string text = txtReceiverAccount.Text.Trim();
            txtReceiverAccountError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtReceiverAccountError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public void txtTransferAmountChangeHandler(object sender, EventArgs e)
        {
            string text = txtTransferAmount.Text.Trim();
            txtTransferAmountError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtTransferAmountError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public void txtReferenceChangeHandler(object sender, EventArgs e)
        {
            string text = txtReference.Text.Trim();
            txtReferenceError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtReferenceError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }


        public async void txtAccountChangeHandler(object sender, EventArgs e)
        {
            string accNo = txtAccNo.Text.Trim();
            txtAccNoError.Text = "";
            errorFound = false;
            if (accNo == "")
            {
                txtAccNoError.Text = "*Can not be empty!";
                errorFound = true;
            }
            if (accNo!="")
            {
                string url = "https://localhost:7134/api/Customer/GetCustomerByAccountNo/"+accNo;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    CustomerResponse res = response.Content.ReadAsAsync<CustomerResponse>().Result;
                    if (res.results.ToArray()[0].CustomerName!="")
                    {
                        txtCutomerName.Text = res.results.ToArray()[0].CustomerName;
                        txtAccountBalance.Text = res.results.ToArray()[0].AccountBalance.ToString();
                    }
                    else
                    {
                        txtCutomerName.Text = "";
                        txtAccountBalance.Text = "";
                    }
                }
                else
                {
                    txtCutomerName.Text = "";
                    txtAccountBalance.Text = "";
                }
            }
        }

        public void txtAmountChangeHandler(object sender, EventArgs e)
        {
            string text = txtAmount.Text.Trim();
            txtAmountError.Text = "";
            errorFound = false;
            if (text == "")
            {
                txtAmountError.Text = "*Can not be empty!";
                errorFound = true;
            }
        }

        public void drpTypeChangehandler(object sender, EventArgs e)
        {
            drpTypeError.Text = "";
            errorFound= false;
            if (drpType.Text == "0" || drpType.Text == "Choose")
            {
                drpTypeError.Text = "*Can not be empty!";
                errorFound=true;
            }
        }

        public void OnClickLogOut(object sender, EventArgs e)
        {
            Main.isLoggedIn = false;
            Response.Redirect("LoginPage.aspx", false);
        }

    }
}