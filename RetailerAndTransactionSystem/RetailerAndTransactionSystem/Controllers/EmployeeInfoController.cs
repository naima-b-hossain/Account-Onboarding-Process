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
    public class EmployeeInfoController : ControllerBase
    {



        [HttpGet]
        public ActionResult<List<EmployeeInfo>> GetEmployees()
        {
            List<EmployeeInfo> result = Db.getAllEmployees();

            return Ok(result);
        }



        [HttpGet("{id}", Name = "GetEmployess")]
        public ActionResult<EmployeeInfo> GetEmployess(string id)
        {
            EmployeeInfo result = Db.getEmployees(id);
            return Ok(result);
        }


        [HttpDelete("{id}", Name = "DeleteEmployees")]
        public ActionResult DeleteEmpoyees(string id)
        {
            bool isDataDeleted = Db.deleteEmployees(id);
            if (isDataDeleted)
            {
                return Ok();
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult PostEmployeeInfo(EmployeeInfo employeeInfo)
        {
            bool employeeInfoCreated = Db.createEmployeeInfo(employeeInfo);
            if (employeeInfoCreated)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut("{id}", Name = "UpdateEmployeeInfo")]
        public ActionResult PutEmployeeInfo(string id, EmployeeInfo employeeInfo)
        {
            bool updatedEmployeeInfo = Db.updateEmployeeInfo(id, employeeInfo);
            if (updatedEmployeeInfo)
            {
                return Ok();
            }
            return BadRequest();
        }




    }
}
