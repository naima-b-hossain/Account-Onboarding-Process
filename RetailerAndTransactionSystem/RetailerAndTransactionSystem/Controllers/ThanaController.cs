using Microsoft.AspNetCore.Mvc;
using RetailerAndTransactionSystem.Database;
using RetailerAndTransactionSystem.Models;

namespace RetailerAndTransactionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanaController:ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Thana>> GetAllThana()
        {
            List<Thana> result = Db.getAllThana();

            return Ok(result);
        }

        [HttpGet("{code}", Name = "GetThanaByDistrict")]
        public ActionResult<List<Thana>> GetThanaByDistrict(string code)
        {
            List<Thana> result = Db.getThanaByDistrict(code);

            return Ok(result);
        }

    }
}
