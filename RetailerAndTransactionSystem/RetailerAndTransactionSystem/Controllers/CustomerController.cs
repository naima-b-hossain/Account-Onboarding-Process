using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using RetailerAndTransactionSystem.Models;
using RetailerAndTransactionSystem.Database;


namespace RetailerAndTransactionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("GetAllCustomers/", Name = "GetCustomers")]
        public ActionResult<CustomerResponse> GetCustomers()
        {
            List<Customer> result = Db.getAllCustomers();
            if (result.Count==0)
            {
                return NotFound(new CustomerResponse(404, "Customers not found", result));
            }
            return Ok(new CustomerResponse(200, "Fetched All Customers", result));
        }

        [HttpGet("GetCustomerByCustomerId/{id}", Name = "GetCustomer")]
        public ActionResult<CustomerResponse> GetCustomer(string id)
        {
            List<Customer> listCustomerObj = new List<Customer>();
            Customer result = Db.getCustomer(id);
            if (result.Id==0)
            {
                return NotFound(new CustomerResponse(404, "Customer not found", listCustomerObj));
            }
            listCustomerObj.Add(result);
            return Ok(new CustomerResponse(200, "Fetched Customer", listCustomerObj));
        }

        [HttpGet("GetMatchedCustomersByCustomerId/{id}", Name = "GetMatchedCustomers")]
        public ActionResult<CustomerResponse> GetMatchedCustomers(string id)
        {
            List<Customer> customers = Db.getCustomers(id);
            if (customers.Count==0)
            {
                return NotFound(new CustomerResponse(404, "Customer not found", customers));
            }
            return Ok(new CustomerResponse(200, "Fetched Customer", customers));
        }

        [HttpGet("GetCustomerByNid/{id}", Name = "GetCustomerByNid")]
        public ActionResult<Customer> GetCustomerByNid(string id)
        {
            List<Customer> listCustomerObj = new List<Customer>();
            Customer result = Db.getCustomerByNid(id);
            if (result.Id==0)
            {
                return NotFound(new CustomerResponse(404, "Customer not found", listCustomerObj));
            }
            listCustomerObj.Add(result);
            return Ok(new CustomerResponse(200, "Fetched Customer", listCustomerObj));
        }

        [HttpGet("GetCustomerByAccountNo/{accountNo}", Name = "GetCustomerByAccountNo")]
        public ActionResult<Customer> GetCustomerByAccountNo(string accountNo)
        {
            List<Customer> listCustomerObj = new List<Customer>();
            Customer result = Db.getCustomerByAccountNo(accountNo);
            if (result.CustomerName==null)
            {
                return NotFound(new CustomerResponse(404, "Customer not found", listCustomerObj));
            }
            listCustomerObj.Add(result);
            return Ok(new CustomerResponse(200, "Fetched Customer", listCustomerObj));
        }

        [HttpPut("UpdateCustomerByCustomerId/{id}", Name = "UpdateCustomer")]
        public ActionResult PutCustomer(string id, Customer customer)
        {
            bool updatedCustomer = Db.updateCustomer(id, customer);
            if (updatedCustomer)
            {
                return Ok();    
            }
            return BadRequest();
        }

        [HttpDelete("DeleteCustomerByCustomerId/{id}", Name = "DeleteCustomer")]
        public ActionResult DeleteCustomer(string id)
        {
            List<Customer> listCustomerObj = new List<Customer>();
            bool isDataDeleted = Db.deleteCustomer(id);
            if (isDataDeleted)
            {
                return Ok(new CustomerResponse(200, "Deleted Customer", listCustomerObj));
            }
            return NotFound(new CustomerResponse(404, "Customer Not Found", listCustomerObj));
        }

        [HttpPost("CreateCustomer/", Name = "PostCustomer")]
        public ActionResult<CustomerResponse> PostCustomer(Customer customer)
        {

            CustomerResponse validateResponse = new(400, "Mandetory fields are required");
            if (customer.Nid==null || customer.Nid.Trim()=="")
            {
                return BadRequest(validateResponse);
            }

            CustomerResponse response = Db.createCustomer(customer);
            if (response.status==200)
            {
                CustomerResponse okResponse = new(response.status, response.message, response.customer_id);
                return Ok(okResponse);
            }
            CustomerResponse badResponse = new(response.status, response.message, response.customer_id);
            return BadRequest(badResponse);
        }

       
    }
}
