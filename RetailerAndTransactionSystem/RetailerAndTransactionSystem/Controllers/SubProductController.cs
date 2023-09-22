using Microsoft.AspNetCore.Mvc;
using RetailerAndTransactionSystem.Database;
using RetailerAndTransactionSystem.Models;

namespace RetailerAndTransactionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProductController:ControllerBase
    {
        [HttpGet("{productType}", Name = "GetSubProductsByProductType")]
        public ActionResult<List<SubProduct>> GetSubProductsByProductType(string productType)
        {
            List<SubProduct> result = Db.getSubProductsByProductType(productType);
            return Ok(result);
        }

    }
}
