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
    public class AccTransactionInfoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<AccTransactionInfo>> GetAllTransactionInfo()
        {
            List<AccTransactionInfo> result = Db.getAllTransactionInfo();
            return Ok(result);
        }



        [HttpGet("{id}", Name = "GetTransactionInfo")]
        public ActionResult<AccTransactionInfo> GetTransactionInfo(string id)
        {
            AccTransactionInfo result = Db.getTransactionInfo(id);
            return Ok(result);
        }

        [HttpGet("Customer/{id}", Name = "GetTransactionsByCustomerId")]
        public ActionResult<AccTransactionInfo> GetTransactionsByCustomerId(string id)
        {
            List<AccTransactionInfo> result = Db.getAllTransactionsByCustomerId(id);
            return Ok(result);
        }

        [HttpGet("Account/{accountNo}", Name = "GetTransactionsByAccountNo")]
        public ActionResult<AccTransactionInfo> GetTransactionsByAccountNo(string accountNo)
        {
            List<AccTransactionInfo> result = Db.getAllTransactionsByAccountNo(accountNo);
            return Ok(result);
        }


        [HttpDelete("{id}", Name = "DeleteTransactionInfo")]
        public ActionResult DeleteTransactionInfo(string id)
        {
            bool isDataDeleted = Db.deleteTransactionInfo(id);
            if (isDataDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult MoneyTransfer(MoneyTransfer moneyTransfer)
        {
            bool moneyTransferSuccess = Db.transferMoney(moneyTransfer);

            if (moneyTransferSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("OwnAccount", Name = "MoneyTransferOwnAccount")]
        public ActionResult MoneyTransferOwnAccount(MoneyTransferOwnAccount moneyTrnasferOwnAccount)
        {
            bool moneyTransferSuccess = Db.transferMoneyOwnAccount(moneyTrnasferOwnAccount);
            if (moneyTransferSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }

        /*
        [HttpPost]
        public ActionResult PostTransactionInfo(AccTransactionInfo transactionInfo)
        {
            bool transactionInfotCreated = Db.createTransactionInfo(transactionInfo);
            if (transactionInfotCreated)
            {
                return Ok();
            }
            return BadRequest();
        }
        */



        [HttpPut("{id}", Name = "UpdateTransactionInfo")]
        public ActionResult PutTransactionInfo(string id, AccTransactionInfo transactionInfo)
        {
            bool updatedTransactionInfo = Db.updateTransactionInfo(id, transactionInfo);
            if (updatedTransactionInfo)
            {
                return Ok();
            }
            return BadRequest();
        }


    }




}

