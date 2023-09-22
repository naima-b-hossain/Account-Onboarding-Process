using System;
using Microsoft.AspNetCore.Mvc;
using RetailerAndTransactionSystem.Database;
using RetailerAndTransactionSystem.Models;
using System.Xml.Linq;

namespace RetailerAndTransactionSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAllAccountProduct()
        {
            List<Product> result = Db.getAllAccountProduct();
            return Ok(result);
        }
    }
}
