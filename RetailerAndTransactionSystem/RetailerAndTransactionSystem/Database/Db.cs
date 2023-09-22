using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RetailerAndTransactionSystem.Models;

namespace RetailerAndTransactionSystem.Database
{
    public class Db
    {
        private static readonly string conString = "Data Source=DESKTOP-3KP73OB;Initial Catalog=RMTS;Integrated Security=True";
        public static List<Customer> listCustomerObj = new List<Customer>();
        public static List<EmployeeInfo> listEmployeeObj = new List<EmployeeInfo>();
        public static List<Account> listAccountObj = new List<Account>();
        public static List<AccTransactionInfo> listTransactionObj = new List<AccTransactionInfo>();
        public static List<Product> listAccProductObj = new List<Product>();
        public static List<SubProduct> listSubProductObj = new List<SubProduct>();
        public static List<Division> listDivisionObj = new List<Division>();
        public static List<District> listDistrictObj = new List<District>();
        public static List<Thana> listThanaObj = new List<Thana>();
        public static List<Login> listLoginObj = new List<Login>();

        //-----------CUSTOMER-----------
        public static List<Customer> getAllCustomers()
        {
            SqlConnection con = new(conString);
            con.Open();
            listCustomerObj.Clear();
            string query1 = "select * from customer";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listCustomerObj.Add(new Customer((int)dr["id"], (string)dr["customer_id"], (string)dr["customer_name"], (string)dr["customer_gender"], (string)dr["customer_father_name"], (string)dr["customer_mother_name"], (string)dr["nid"], (DateTime)dr["dob"], (string)dr["religion"], (string)dr["occupation"], (double)dr["monthly_income"], (string)dr["phone_no"], (string)dr["per_address"], (string)dr["per_division"], (string)dr["per_district"], (string)dr["per_thana"], (string)dr["per_postal_code"], (string)dr["pre_address"], (string)dr["pre_division"], (string)dr["pre_district"], (string)dr["pre_thana"], (string)dr["pre_postal_code"], (string)dr["com_address"], (string)dr["com_division"], (string)dr["com_district"], (string)dr["com_thana"], (string)dr["com_postal_code"], (string)dr["employee_id"]));
            }
            con.Close();
            return listCustomerObj;
        }

        public static Customer getCustomer(string customer_id)
        {

            SqlConnection con = new(conString);
            con.Open();
            string query1 = "select id, customer_id, customer_name, customer_gender, customer_father_name, customer_mother_name, nid, dob, religion, occupation, monthly_income, phone_no, per_address,per_division,per_district, per_thana, per_postal_code, pre_address, pre_division, pre_district, pre_thana, pre_postal_code, com_address, com_division, com_district, com_thana, com_postal_code, employee_id from customer where customer_id='"+customer_id+"'";
            SqlCommand cmd = new SqlCommand(query1, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Customer obj;
            if (sqlDataReader.Read())
            {
                obj = new Customer((int)sqlDataReader[0], (string)sqlDataReader[1], (string)sqlDataReader[2], (string)sqlDataReader[3], (string)sqlDataReader[4], (string)sqlDataReader[5], (string)sqlDataReader[6], (DateTime)sqlDataReader[7], (string)sqlDataReader[8], (string)sqlDataReader[9], (double)sqlDataReader[10], (string)sqlDataReader[11], (string)sqlDataReader[12], (string)sqlDataReader[13], (string)sqlDataReader[14], (string)sqlDataReader[15], (string)sqlDataReader[16], (string)sqlDataReader[17], (string)sqlDataReader[18], (string)sqlDataReader[19], (string)sqlDataReader[20], (string)sqlDataReader[21], (string)sqlDataReader[22], (string)sqlDataReader[23], (string)sqlDataReader[24], (string)sqlDataReader[25], (string)sqlDataReader[26], (string)sqlDataReader[27]);
                con.Close();
                return obj;
            }
            return new Customer();
        }

        public static List<Customer> getCustomers(string customer_id)
        {

            SqlConnection con = new(conString);
            con.Open();
            listCustomerObj.Clear();
            string query1 = "select id, customer_id, customer_name, customer_gender, customer_father_name, customer_mother_name, nid, dob, religion, occupation, monthly_income, phone_no, per_address,per_division,per_district, per_thana, per_postal_code, pre_address, pre_division, pre_district, pre_thana, pre_postal_code, com_address, com_division, com_district, com_thana, com_postal_code, employee_id from customer where customer_id like '%"+customer_id+"%'";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listCustomerObj.Add(new Customer((int)dr["id"], (string)dr["customer_id"], (string)dr["customer_name"], (string)dr["customer_gender"], (string)dr["customer_father_name"], (string)dr["customer_mother_name"], (string)dr["nid"], (DateTime)dr["dob"], (string)dr["religion"], (string)dr["occupation"], (double)dr["monthly_income"], (string)dr["phone_no"], (string)dr["per_address"], (string)dr["per_division"], (string)dr["per_district"], (string)dr["per_thana"], (string)dr["per_postal_code"], (string)dr["pre_address"], (string)dr["pre_division"], (string)dr["pre_district"], (string)dr["pre_thana"], (string)dr["pre_postal_code"], (string)dr["com_address"], (string)dr["com_division"], (string)dr["com_district"], (string)dr["com_thana"], (string)dr["com_postal_code"], (string)dr["employee_id"]));
            }
            con.Close();
            return listCustomerObj;
        }
        public static Customer getCustomerByAccountNo(string accountNo)
        {
            Account accountObj = getAccount(accountNo);
            if (accountObj.CustomerId!="")
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "select customer_name from customer where customer_id='"+accountObj.CustomerId+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                Customer obj;
                if (sqlDataReader.Read())
                {
                    obj = new Customer((string)sqlDataReader[0], accountObj.Balance);
                    con.Close();
                    return obj;
                }
                return new Customer();
            }
            return new Customer();
        }
        public static Customer getCustomerByNid(string nid)
        {
            SqlConnection con = new(conString);
            con.Open();
            string query1 = "select id, customer_id, customer_name, customer_gender, customer_father_name, customer_mother_name, nid, dob, religion, occupation, monthly_income, phone_no, per_address,per_division,per_district, per_thana, per_postal_code, pre_address, pre_division, pre_district, pre_thana, pre_postal_code, com_address, com_division, com_district, com_thana, com_postal_code, employee_id from customer where nid='"+nid+"' or phone_no='"+nid+"'";
            SqlCommand cmd = new SqlCommand(query1, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Customer obj;
            if (sqlDataReader.Read())
            {
                obj = new Customer((int)sqlDataReader[0], (string)sqlDataReader[1], (string)sqlDataReader[2], (string)sqlDataReader[3], (string)sqlDataReader[4], (string)sqlDataReader[5], (string)sqlDataReader[6], (DateTime)sqlDataReader[7], (string)sqlDataReader[8], (string)sqlDataReader[9], (double)sqlDataReader[10], (string)sqlDataReader[11], (string)sqlDataReader[12], (string)sqlDataReader[13], (string)sqlDataReader[14], (string)sqlDataReader[15], (string)sqlDataReader[16], (string)sqlDataReader[17], (string)sqlDataReader[18], (string)sqlDataReader[19], (string)sqlDataReader[20], (string)sqlDataReader[21], (string)sqlDataReader[22], (string)sqlDataReader[23], (string)sqlDataReader[24], (string)sqlDataReader[25], (string)sqlDataReader[26], (string)sqlDataReader[27]);
                con.Close();
                return obj;
            }
            return new Customer();

        }
        
        public static bool updateCustomer(string customer_id, Customer customer)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "update customer set customer_name='"+customer.CustomerName+"', customer_gender='"+customer.CustomerGender+"', customer_father_name='"+customer.CustomerFatherName+"', customer_mother_name='"+customer.CustomerMotherName+"', nid='"+customer.Nid+"', dob='"+customer.Dob+"', religion='"+customer.Religion+"', occupation='"+customer.Occupation+"', monthly_income='"+customer.MonthlyIncome+"', phone_no='"+customer.PhoneNo+"', '"+customer.PerAddress+"', '"+customer.PerDivision+"', '"+customer.PerDistrict+"', '"+customer.PerThana+"', '"+customer.PerPostalCode+"', '"+customer.PreAddress+"', '"+customer.PreDivision+"', '"+customer.PreDistrict+"', '"+customer.PreThana+"', '"+customer.PrePostalCode+"', '"+customer.ComAddress+"', '"+customer.ComDivision+"', '"+customer.ComDistrict+"', '"+customer.ComThana+"', '"+customer.ComPostalCode+"', employee_id='"+customer.EmployeeId+"' where customer_id='"+customer_id+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool deleteCustomer(string customer_id)
        {
            SqlConnection con = new(conString);
            con.Open();
            string query1 = "select customer_id from customer where customer_id='"+customer_id+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                con.Close();
                con.Open();
                query1 = "delete from customer where customer_id='"+customer_id+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            return false;
        }
        
        public static CustomerResponse createCustomer(Customer customer)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "select customer_id, nid from customer where nid='"+customer.Nid+"'";
                SqlDataAdapter sda = new(query1, con);
                DataTable dt = new();
                sda.Fill(dt);
                bool customerFound = false;
                string foundCustomerId = "";
                foreach (DataRow dr in dt.Rows)
                {
                    if ((string)dr["nid"]==customer.Nid)
                    {
                        customerFound = true;
                        foundCustomerId = (string)dr["customer_id"];
                    }
                }
                con.Close();
                if (customerFound==false)
                {
                    con.Open();
                    string customerId = "c_";
                    query1 = "SELECT TOP 1 customer_id FROM customer ORDER BY id DESC"; 
                    sda = new(query1, con);
                    dt = new();
                    sda.Fill(dt);
                    string lastCreatedCustomerId = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        lastCreatedCustomerId = (string)dr["customer_id"];
                    }
                    char[] spearator = {'_'};
                    Int32 count = 2;
                    if (lastCreatedCustomerId!="")
                    {
                        String[] strlist = lastCreatedCustomerId.Split(spearator, count, StringSplitOptions.None);
                        int lastCreatedAccountNoPart = int.Parse(strlist[1])+1;
                        for (int i = 0; i<8-lastCreatedAccountNoPart.ToString().Length; i++)
                        {
                            customerId+="0";
                        }
                        customerId+=lastCreatedAccountNoPart.ToString();
                    }
                    else
                    {
                        customerId = "c_00000001";
                    }
                    con.Close();
                    con.Open();
                    query1 = "insert into customer (customer_id, customer_name, customer_gender, customer_father_name, customer_mother_name, nid, dob, religion, occupation, monthly_income, phone_no, per_address,per_division,per_district, per_thana, per_postal_code, pre_address, pre_division, pre_district, pre_thana, pre_postal_code, com_address, com_division, com_district, com_thana, com_postal_code, employee_id) values ('"+customerId+"', '"+customer.CustomerName+"', '"+customer.CustomerGender+"', '"+customer.CustomerFatherName+"', '"+customer.CustomerMotherName+"', '"+customer.Nid+"', '"+customer.Dob+"', '"+customer.Religion+"', '"+customer.Occupation+"', '"+customer.MonthlyIncome+"', '"+customer.PhoneNo+"', '"+customer.PerAddress+"', '"+customer.PerDivision+"', '"+customer.PerDistrict+"', '"+customer.PerThana+"', '"+customer.PerPostalCode+"', '"+customer.PreAddress+"', '"+customer.PreDivision+"', '"+customer.PreDistrict+"', '"+customer.PreThana+"', '"+customer.PrePostalCode+"', '"+customer.ComAddress+"', '"+customer.ComDivision+"', '"+customer.ComDistrict+"', '"+customer.ComThana+"', '"+customer.ComPostalCode+"', '"+customer.EmployeeId+"')";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    con.Close();
                    return new CustomerResponse(200, "Customer Created Successfully", customerId); ;
                }
                return new CustomerResponse(204, "Customer Already Exist", foundCustomerId);
            }
            catch (Exception ex)
            {
                return new CustomerResponse(500, "Internal Server  Error");
            }
        }

        










        //--------Employee--------------------

        public static List<EmployeeInfo> getAllEmployees()
        {
            SqlConnection con = new(conString);
            con.Open();
            listEmployeeObj.Clear();
            string query1 = "select * from employee_info";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeInfo tempObj = new((int)dr["id"], (string)dr["employee_id"], (string)dr["employee_name"], (string)dr["employee_phone_no"], (string)dr["branch_code"], (string)dr["branch_name"]);
                listEmployeeObj.Add(tempObj);
            }
            con.Close();
            return listEmployeeObj;

        }



        public static EmployeeInfo getEmployees(string employee_id)
        {

            SqlConnection con = new(conString);
            con.Open();
            string query1 = "select id, employee_id, employee_name, employee_phone_no, branch_code, branch_name from employee_info where employee_id='"+employee_id+"'";
            SqlCommand cmd = new SqlCommand(query1, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();
            EmployeeInfo obj = new((int)sqlDataReader[0], (string)sqlDataReader[1], (string)sqlDataReader[2], (string)sqlDataReader[3], (string)sqlDataReader[4], (string)sqlDataReader[5]);
            con.Close();
            return obj;

        }

        public static bool deleteEmployees(string employee_id)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "delete from employee_info where employee_id='"+employee_id+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex) { return false; }

        }

        public static bool createEmployeeInfo(EmployeeInfo employeeInfo)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "insert into employee_info (employee_id, employee_name, employee_phone_no, branch_code,branch_name ) values ('"+employeeInfo.EmployeeId+"', '"+employeeInfo.EmployeeName+"', '"+employeeInfo.EmployeePhoneNo+"', '"+employeeInfo.BranchCode+"', '"+employeeInfo.BranchName+"' )";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public static bool updateEmployeeInfo(string employee_id, EmployeeInfo employeeInfo)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "update employee_info set employee_name='"+employeeInfo.EmployeeName+"', employee_phone_no='"+employeeInfo.EmployeePhoneNo+"', branch_code='"+employeeInfo.BranchCode+"', branch_name='"+employeeInfo.BranchName+"' where employee_id='"+employee_id+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }






        //-------------Account--------------

        public static List<Account> getAllAccounts()
        {
            SqlConnection con = new(conString);
            con.Open();
            listAccountObj.Clear();
            string query1 = "select * from account";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listAccountObj.Add(new Account((int)dr["id"], (string)dr["account_no"], (string)dr["customer_id"], (string)dr["product_type"], (double)dr["balance"], (DateTime)dr["acc_created_date"], (string)dr["acc_status"], (string)dr["branch_code"], (string)dr["acc_open_by"], (string)dr["sub_product_type"]));
            }
            con.Close();
            return listAccountObj;
        }



        public static Account getAccount(string account_no)
        {

            SqlConnection con = new(conString);
            con.Open();
            string query1 = "select id, account_no, customer_id, product_type, balance, acc_created_date, acc_status, branch_code, acc_open_by, sub_product_type from account where account_no='"+account_no+"'";
            SqlCommand cmd = new SqlCommand(query1, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Account obj;
            if (sqlDataReader.Read())
            {
                obj = new((int)sqlDataReader[0], (string)sqlDataReader[1], (string)sqlDataReader[2], (string)sqlDataReader[3], (double)sqlDataReader[4], (DateTime)sqlDataReader[5], (string)sqlDataReader[6], (string)sqlDataReader[7], (string)sqlDataReader[8], (string)sqlDataReader[9]);
            }
            else
            {
                obj = new();
            }
            con.Close();
            return obj;
        }

        public static List<Account> getAccounts(string customer_id)
        {
            SqlConnection con = new(conString);
            con.Open();
            string query1 = "select id, account_no, customer_id, product_type, balance, acc_created_date, acc_status, branch_code, acc_open_by, sub_product_type from account where customer_id='"+customer_id+"'";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            con.Close();
            listAccountObj.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                con.Open();
                query1 = "select product_name from account_product where product_type='"+(string)dr["product_type"]+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                String productName = "";
                if (sqlDataReader.Read())
                {
                    char[] spearator = { '-' };
                    Int32 count = 2;
                    productName = ((String)sqlDataReader[0]).Split(spearator, count, StringSplitOptions.None)[0];
                }
                con.Close();
                con.Open();
                query1 = "select sub_product_name from account_sub_products where sub_product_type='"+(string)dr["sub_product_type"]+"'";
                cmd = new SqlCommand(query1, con);
                sqlDataReader = cmd.ExecuteReader();
                String subProductName = "";
                if (sqlDataReader.Read())
                {
                    subProductName = (String)sqlDataReader[0];
                }
                con.Close();


                listAccountObj.Add(new Account((int)dr["id"], (string)dr["account_no"], (string)dr["customer_id"], productName, (double)dr["balance"], (DateTime)dr["acc_created_date"], (string)dr["acc_status"], (string)dr["branch_code"], (string)dr["acc_open_by"], subProductName));
                
            }
            
            return listAccountObj;

        }

        public static bool deleteAccount(string account_no)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "delete from account where account_no='"+account_no+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex) { return false; }

        }

        public static string createAccount(Account account)
        {
            int lastAccountId = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT MAX(id) FROM account", connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastAccountId = (int)result;
                    }
                }
            }
            // Generate the account number
            //string productTypeNumber = account.ProductType;
            string productTypeNumber = account.ProductType.ToString().PadLeft(4, '0');
            string subProductTypeNumber = account.SubProductType.ToString().PadLeft(4, '0');
            string accountIdPart = (lastAccountId + 1).ToString().PadLeft(5, '0');
            string accountNo = productTypeNumber +subProductTypeNumber+accountIdPart;
            bool accountExists = false;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT account_no FROM account WHERE account_no LIKE @AccountNumber", connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", "%" + accountNo.Substring(4) + "%");
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            accountExists = true;
                        }
                    }
                }
            }
            if (accountExists)
            {
                return "";
            }
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                string query1 = "insert into account (account_no, customer_id, product_type, balance, acc_created_date, acc_status, branch_code, acc_open_by, sub_product_type ) values ('"+accountNo+"', '"+account.CustomerId+"', '"+account.ProductType+"', "+account.Balance+", '"+account.AccCreatedDate+"' ,'"+account.AccStatus+"','"+account.BranchCode+"','"+account.AccOpenBy+"','"+account.SubProductType+"' )";
                SqlCommand cmd = new SqlCommand(query1, connection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                connection.Close();
                return accountNo;
            }
        }

        public static bool updateAccountBalance(string account_no, double balance)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "update account set balance='"+balance+"' where account_no='"+account_no+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool updateAccount(string account_no, Account account)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "update account set customer_id='"+account.CustomerId+"', product_type='"+account.ProductType+"', balance='"+account.Balance+"', acc_created_date='"+account.AccCreatedDate+"',acc_status='"+account.AccStatus+"',branch_code='"+account.BranchCode+"' where account_no='"+account_no+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        //----------------TransactionInfo-------------


        


        public static List<AccTransactionInfo> getAllTransactionInfo()
        {
            SqlConnection con = new(conString);
            con.Open();
            listTransactionObj.Clear();
            string query1 = "select * from transaction_info";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                AccTransactionInfo tempObj = new((int)dr["id"], (string)dr["transaction_id"], (string)dr["account_no"], (string)dr["transaction_type"], (DateTime)dr["transaction_date"], (double)dr["tran_ammount"], (string)dr["narration"], (string)dr["transaction_to"]);
                listTransactionObj.Add(tempObj);
            }
            
            con.Close();
            return listTransactionObj;

        }


        public static AccTransactionInfo getTransactionInfo(string transaction_id)
        {

            SqlConnection con = new(conString);
            con.Open();
            listTransactionObj.Clear();
            string query1 = "select id, transaction_id, account_no, transaction_type, transaction_date, tran_ammount, narration, transaction_to from transaction_info where transaction_id='"+transaction_id+"'";
            SqlCommand cmd = new SqlCommand(query1, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            sqlDataReader.Read();
            AccTransactionInfo obj = new((int)sqlDataReader[0], (string)sqlDataReader[1], (string)sqlDataReader[2], (string)sqlDataReader[3], (DateTime)sqlDataReader[4], (double)sqlDataReader[5], (string)sqlDataReader[6], (string)sqlDataReader[7]);
            con.Close();
            return obj;

        }

        //public static List<AccTransactionInfo> getAllTransactionsByCustomerId(string customer_id)
        //{
        //    SqlConnection con = new(conString);
        //    con.Open();
        //    listTransactionObj.Clear();
        //    List<Account> accounts = getAccounts(customer_id);
        //    foreach (Account account in accounts)
        //    {
        //        string query1 = "select id, transaction_id, account_no, transaction_type, transaction_date, tran_ammount, narration, transaction_to from transaction_info where account_no='"+account.AccountNo+"' order by id asc";
        //        SqlDataAdapter sda = new(query1, con);
        //        DataTable dt = new();
        //        sda.Fill(dt);
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            listTransactionObj.Add(new((int)dr["id"], (string)dr["transaction_id"], (string)dr["account_no"], (string)dr["transaction_type"], (DateTime)dr["transaction_date"], (double)dr["tran_ammount"], (string)dr["narration"], (string)dr["transaction_to"]));
        //        }
        //    }
        //    con.Close();
        //    return listTransactionObj;
        //}
        public static List<AccTransactionInfo> getAllTransactionsByAccountNo(string accountNo)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            listTransactionObj.Clear();

            string query1 = "select id, transaction_id, account_no, transaction_type, transaction_date, tran_ammount, narration, transaction_to from transaction_info where account_no='" + accountNo + "' order by id asc";
            SqlDataAdapter sda = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                string transacttionTo = (string)dr["transaction_to"];
                if (accountNo==transacttionTo)
                {
                    transacttionTo = "";
                }
                listTransactionObj.Add(new AccTransactionInfo(
                    (int)dr["id"],
                    (string)dr["transaction_id"],
                    (string)dr["account_no"],
                    (string)dr["transaction_type"],
                    (DateTime)dr["transaction_date"],
                    (double)dr["tran_ammount"],
                    (string)dr["narration"],
                    transacttionTo
                ));
            }
            con.Close();
            return listTransactionObj;
        }
        public static List<AccTransactionInfo> getAllTransactionsByCustomerId(string customer_id)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            listTransactionObj.Clear();
            List<Account> accounts = getAccounts(customer_id);

            Console.WriteLine("Total accounts: " + accounts.Count);

            foreach (Account account in accounts.ToList())
            {
                string query1 = "select id, transaction_id, account_no, transaction_type, transaction_date, tran_ammount, narration, transaction_to from transaction_info where account_no='" + account.AccountNo + "' order by id asc";
                SqlDataAdapter sda = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                Console.WriteLine("Account: " + account.AccountNo + " - Total transactions: " + dt.Rows.Count);

                foreach (DataRow dr in dt.Rows)
                {
                    listTransactionObj.Add(new AccTransactionInfo(
                        (int)dr["id"],
                        (string)dr["transaction_id"],
                        (string)dr["account_no"],
                        (string)dr["transaction_type"],
                        (DateTime)dr["transaction_date"],
                        (double)dr["tran_ammount"],
                        (string)dr["narration"],
                        (string)dr["transaction_to"]
                    ));
                }
            }
            con.Close();

            Console.WriteLine("Total transactions retrieved: " + listTransactionObj.Count);


            return listTransactionObj;
        }






        public static bool deleteTransactionInfo(string transaction_id)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "delete from transaction_info where transaction_id='"+transaction_id+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex) { return false; }

        }

        public static bool createTransactionInfo(AccTransactionInfo transactionInfo)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "insert into transaction_info (transaction_id, account_no, transaction_type, transaction_date,tran_ammount, narration, transaction_to ) values ('"+transactionInfo.TransactionId+"', '"+transactionInfo.AccountNo+"', '"+transactionInfo.TransactionType+"', '"+transactionInfo.TransactionDate+"', '"+transactionInfo.TranAmmount+"','"+transactionInfo.Narration+"','"+transactionInfo.TransactionTo+"')";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //------------Money Transfer--------
        public static bool transferMoney(MoneyTransfer moneyTransfer)
        {
            try
            {
                Account senderAccountInfoByAccoutNo = getAccount(moneyTransfer.SenderAccountNo);
                Account receiverAccountInfoByAccoutNo = getAccount(moneyTransfer.ReceiverAccountNo);
                if(senderAccountInfoByAccoutNo.Balance>=moneyTransfer.TransferAmount) {
                    bool debitedFromSender = updateAccountBalance(moneyTransfer.SenderAccountNo, senderAccountInfoByAccoutNo.Balance-moneyTransfer.TransferAmount);
                    bool creditedToReceiver = updateAccountBalance(moneyTransfer.ReceiverAccountNo, receiverAccountInfoByAccoutNo.Balance+moneyTransfer.TransferAmount);
                    SqlConnection con = new(conString);
                    con.Open();
                    string transactionId = "";
                    string query = "SELECT TOP 1 transaction_id FROM transaction_info ORDER BY id DESC";
                    SqlDataAdapter sda = new(query, con);
                    DataTable dt = new();
                    sda.Fill(dt);
                    string lastCreatedTransactionId = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        lastCreatedTransactionId = (string)dr["transaction_id"];
                    }
                    if (lastCreatedTransactionId=="")
                    {
                        transactionId = "0000001";
                    }
                    else
                    {
                        for (int i = 0; i<7-(int.Parse(lastCreatedTransactionId)+1).ToString().Length; i++)
                        {
                            transactionId+="0";
                        }
                        transactionId+=(int.Parse(lastCreatedTransactionId)+1).ToString();
                    }
                    string transactionIdTwo = "";
                    for (int i = 0; i<7-(int.Parse(transactionId)+1).ToString().Length; i++)
                    {
                        transactionIdTwo+="0";
                    }
                    transactionIdTwo+=(int.Parse(transactionId)+1).ToString();
                    bool createTransectionInfoForSender = createTransactionInfo(new AccTransactionInfo(0, transactionId, moneyTransfer.SenderAccountNo, "Debit", DateTime.Now, moneyTransfer.TransferAmount, moneyTransfer.Reference, moneyTransfer.ReceiverAccountNo));
                    bool createTransectionInfoForReceiver = createTransactionInfo(new AccTransactionInfo(0, transactionIdTwo, moneyTransfer.ReceiverAccountNo, "Credit", DateTime.Now, moneyTransfer.TransferAmount, moneyTransfer.Reference, moneyTransfer.SenderAccountNo));
                    if (debitedFromSender && creditedToReceiver && createTransectionInfoForSender && createTransectionInfoForReceiver)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool transferMoneyOwnAccount(MoneyTransferOwnAccount moneyTrnasferOwnAccount)
        {
            try
            {
                string accountNo = moneyTrnasferOwnAccount.AccountNo;
                double transferAmount = moneyTrnasferOwnAccount.TransferAmount;
                string transferType = moneyTrnasferOwnAccount.TransferType;
                Account accountInfo = getAccount(accountNo);
                bool isAccountBalanceUpdated = false, isTransectionTableUpdated=false;
                SqlConnection con = new(conString);
                con.Open();
                string transactionId = "";
                string query = "SELECT TOP 1 transaction_id FROM transaction_info ORDER BY id DESC";
                SqlDataAdapter sda = new(query, con);
                DataTable dt = new();
                sda.Fill(dt);
                string lastCreatedTransactionId = "";
                foreach (DataRow dr in dt.Rows)
                {
                    lastCreatedTransactionId = (string)dr["transaction_id"];
                }
                if (lastCreatedTransactionId=="")
                {
                    transactionId = "0000001";
                }
                else
                {
                    for (int i = 0; i<7-(int.Parse(lastCreatedTransactionId)+1).ToString().Length; i++)
                    {
                        transactionId+="0";
                    }
                    transactionId+=(int.Parse(lastCreatedTransactionId)+1).ToString();
                }

                if (transferType=="1")
                {
                    isAccountBalanceUpdated = updateAccountBalance(accountNo, accountInfo.Balance-transferAmount);
                    isTransectionTableUpdated = createTransactionInfo(new AccTransactionInfo(0, transactionId, accountNo, "Debit", DateTime.Now, transferAmount, "Withdraw", accountNo));
                }
                else if (transferType=="2")
                {
                    isAccountBalanceUpdated = updateAccountBalance(accountNo, accountInfo.Balance+transferAmount);
                    isTransectionTableUpdated = createTransactionInfo(new AccTransactionInfo(0, transactionId, accountNo, "Credit", DateTime.Now, transferAmount, "Deposite", accountNo));
                }
                if (isAccountBalanceUpdated && isTransectionTableUpdated)
                {
                    return true;
                }
                return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool updateTransactionInfo(string transaction_id, AccTransactionInfo transactionInfo)
        {
            try
            {
                SqlConnection con = new(conString);
                con.Open();
                string query1 = "update transaction_info set transaction_id='"+transactionInfo.TransactionId+"', account_no='"+transactionInfo.AccountNo+"', transaction_type='"+transactionInfo.TransactionType+"', transaction_date='"+transactionInfo.TransactionDate+"',tran_ammount='"+transactionInfo.TranAmmount+"' ,narration='"+transactionInfo.Narration+"' where transaction_id='"+transaction_id+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }





        //-------------AccountProduct--------------

        public static List<Product> getAllAccountProduct()
        {
            SqlConnection con = new(conString);
            con.Open();
            listAccProductObj.Clear();
            string query1 = "select * from account_product";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listAccProductObj.Add(new Product((int)dr["id"], (string)dr["product_type"], (string)dr["product_name"]));
            }
            con.Close();
            return listAccProductObj;
        }


        //-------------SUB product--------------

        public static List<SubProduct> getSubProductsByProductType(string productType)
        {
            SqlConnection con = new(conString);
            con.Open();
            listSubProductObj.Clear();
            string query1 = "select * from account_sub_products where product_type='"+productType+"'";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listSubProductObj.Add(new SubProduct((int)dr["id"], (string)dr["sub_product_type"], (string)dr["product_type"], (string)dr["sub_product_name"]));
            }
            con.Close();
            return listSubProductObj;
        }
        //public static Account getAccountProduct(string account_no)
        //{

        //    SqlConnection con = new(conString);
        //    con.Open();
        //    string query1 = "select id, product_type, product_name from account where account_no='"+account_no+"'";
        //    SqlCommand cmd = new SqlCommand(query1, con);
        //    SqlDataReader sqlDataReader = cmd.ExecuteReader();
        //    sqlDataReader.Read();
        //    Account obj = new((int)sqlDataReader[0], (string)sqlDataReader[1], (string)sqlDataReader[2], (string)sqlDataReader[3], (double)sqlDataReader[4], (DateTime)sqlDataReader[5], (string)sqlDataReader[6], (string)sqlDataReader[7]);
        //    con.Close();
        //    return obj;

        //}


        //-------------Division--------------

        public static List<Division> getAllDivision()
        {
            SqlConnection con = new(conString);
            con.Open();
            listDivisionObj.Clear();
            string query1 = "select * from division_tbl";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listDivisionObj.Add(new Division((int)dr["id"], (string)dr["division_code"], (string)dr["div_name"]));
            }
            con.Close();
            return listDivisionObj;
        }




        //-------------District--------------

        public static List<District> getAllDistrict()
        {
            SqlConnection con = new(conString);
            con.Open();
            listDistrictObj.Clear();
            string query1 = "select * from district_tbl";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listDistrictObj.Add(new District((int)dr["id"], (string)dr["district_code"], (string)dr["division_code"], (string)dr["dis_name"]));
            }
            con.Close();
            return listDistrictObj;
        }


        public static List<District>  getDistrictsByDivision(string code)
        {
            SqlConnection con = new(conString);
            con.Open();
            listDistrictObj.Clear();
            string query1 = "select * from district_tbl where division_code="+code;
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listDistrictObj.Add(new District((int)dr["id"], (string)dr["district_code"], (string)dr["division_code"], (string)dr["dis_name"]));
            }
            con.Close();
            return listDistrictObj;
        }


        //-------THANA--------------

        public static List<Thana> getAllThana()
        {
            SqlConnection con = new(conString);
            con.Open();
            listThanaObj.Clear();
            string query1 = "select * from thana_tbl";
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listThanaObj.Add(new Thana((int)dr["id"], (string)dr["thana_code"], (string)dr["district_code"], (string)dr["thana_name"]));
            }
            con.Close();
            return listThanaObj;
        }


        public static List<Thana> getThanaByDistrict(string code)
        {
            SqlConnection con = new(conString);
            con.Open();
            listThanaObj.Clear();
            string query1 = "select * from thana_tbl where district_code="+code;
            SqlDataAdapter sda = new(query1, con);
            DataTable dt = new();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listThanaObj.Add(new Thana((int)dr["id"], (string)dr["thana_code"], (string)dr["district_code"], (string)dr["thana_name"]));
            }
            con.Close();
            return listThanaObj;
        }



        //------Login----

        public static Login Login(Login data)
        {
            try
            {


                SqlConnection con = new(conString);
                con.Open();
                listThanaObj.Clear();
                string query1 = "select * from user_tbl where emp_email='"+data.EmpEmail+"' and emp_password='"+data.EmpPassword+"'";
                SqlCommand cmd = new SqlCommand(query1, con);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                String productName = "";
                listLoginObj.Clear();
                if (sqlDataReader.Read())
                {
                    listLoginObj.Add(new Login((int)sqlDataReader[0], (String)sqlDataReader[1], (String)sqlDataReader[2], (String)sqlDataReader[3]));
                    return listLoginObj[0];
                }
                else
                {
                    return new Login();
                }
            }
            catch (Exception ex)
            {
                return new Login();
            }


        }




    }



}
