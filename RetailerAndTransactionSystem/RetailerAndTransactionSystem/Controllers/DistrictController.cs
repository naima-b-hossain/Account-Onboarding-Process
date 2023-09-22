using Microsoft.AspNetCore.Mvc;
using RetailerAndTransactionSystem.Database;
using RetailerAndTransactionSystem.Models;

namespace RetailerAndTransactionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : Controller
    {

        [HttpGet]
        public ActionResult<List<District>> GetAllDistrict()
        {
            List<District> result = Db.getAllDistrict();

            return Ok(result);
        }

        [HttpGet("{code}", Name = "GetDistrictsByDivision")]
        public ActionResult<List<District>> GetDistrictsByDivision(string code)
        {
            List<District> result = Db.getDistrictsByDivision(code);

            return Ok(result);
        }
    }
}
