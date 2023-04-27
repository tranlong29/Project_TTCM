using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System.Linq;

namespace Project_TTCM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductConfgController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductConfgController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetALl()
        {
            var listProdcut_Confg = _context.product_Configs.ToList();
            return Ok(listProdcut_Confg);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var prodcut_Confg = _context.product_Configs.SingleOrDefault(x => x.Id == id);
            if (prodcut_Confg == null)
            {
                return BadRequest();
            }
            return Ok(prodcut_Confg);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductConfgDTO product_ConfgModel)
        {
            try
            {
                var prodcut_Confg = new Product_Config
                {
                    IdProduct = product_ConfgModel.IdProduct,
                    IdConfig = product_ConfgModel.IdConfig,
                    Value = product_ConfgModel.Value
                };
                _context.Add(prodcut_Confg);
                _context.SaveChanges();
                return Ok(prodcut_Confg);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, ProductConfgDTO product_ConfgModel)
        {
            try
            {
                var prodcut_Confg = _context.product_Configs.SingleOrDefault(x => x.Id == id);
                if (prodcut_Confg == null)
                {
                    return NotFound();
                }
                prodcut_Confg.IdProduct = product_ConfgModel.IdProduct;
                prodcut_Confg.IdConfig = product_ConfgModel.IdConfig;
                prodcut_Confg.Value = product_ConfgModel.Value;


                _context.SaveChanges();
                return Ok(prodcut_Confg);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var prodcut_Confg = _context.product_Configs.SingleOrDefault(x => x.Id == id);
                if (prodcut_Confg == null)
                {
                    return NotFound();
                }
                _context.Remove(prodcut_Confg);
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
