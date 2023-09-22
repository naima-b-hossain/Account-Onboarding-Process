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
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Account>> GetAllAccounts()
        {
            List<Account> result = Db.getAllAccounts();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetAccount")]
        public ActionResult<Account> GetAccount(string id)
        {
            Account account = Db.getAccount(id);
            if (account.AccountNo==null)
            {
                return NotFound(account);
            }
            else
            {
                return Ok(account);
            }
        }

        [HttpGet("Customer/{id}", Name = "GetAccounts")]
        public ActionResult<List<Account>> GetAccounts(string id)
        {
            List<Account> accounts = Db.getAccounts(id);
            return Ok(accounts);
        }

        [HttpDelete("{id}", Name = "DeleteAccount")]
        public ActionResult DeleteAccount(string id)
        {
            bool isDataDeleted = Db.deleteAccount(id);
            if (isDataDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<AccountResponse> PostAccount(Account account)
        {
            string account_no = Db.createAccount(account);
            if (account_no!="")
            {
                return Ok(new AccountResponse(201, "Account Created Successfully", account_no));
            }
            return BadRequest(new AccountResponse(400, "Bad Request"));
        }

        [HttpPut("{id}", Name = "UpdateAccount")]
        public ActionResult PutAccount(string id, Account account)
        {
            bool updatedAccount = Db.updateAccount(id, account);
            if (updatedAccount)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}