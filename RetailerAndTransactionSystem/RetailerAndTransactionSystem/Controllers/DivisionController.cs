using Microsoft.AspNetCore.Mvc;
using RetailerAndTransactionSystem.Database;
using RetailerAndTransactionSystem.Models;

namespace RetailerAndTransactionSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    
    {
        [HttpGet]
        public ActionResult<List<Division>> GetAllDivision()
        {
            List<Division> result = Db.getAllDivision();

            return Ok(result);
        }
    }
}
