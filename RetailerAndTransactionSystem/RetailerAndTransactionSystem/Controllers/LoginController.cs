using Microsoft.AspNetCore.Mvc;
using RetailerAndTransactionSystem.Database;
using RetailerAndTransactionSystem.Models;

namespace RetailerAndTransactionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public ActionResult<Login> PostLogin(Login data)
        {
            Login login = Db.Login(data);
            if(login.EmpEmail == null) {
                return BadRequest(login);
            }
            return Ok(login);
        }
    }
}
