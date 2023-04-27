using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System.Linq;
using System.Xml.Linq;

namespace Project_TTCM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductImageController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetALl()
        {
            var listProdcut_Img = _context.Product_Images.ToList();
            return Ok(listProdcut_Img);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var prodcut_Img = _context.Product_Images.SingleOrDefault(x => x.Id == id);
            if (prodcut_Img == null)
            {
                return BadRequest();
            }
            return Ok(prodcut_Img);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductImgDTO product_ImgModel)
        {
            try
            {
                var prodcut_Img = new Product_Image
                {
                    Name = product_ImgModel.Name,
                    URLIMG = product_ImgModel.URLIMG,
                    IdProduct = product_ImgModel.IdProduct,
                };
                _context.Add(prodcut_Img);
                _context.SaveChanges();
                return Ok(prodcut_Img);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, ProductImgDTO product_ImgModel)
        {
            try
            {
                var prodcut_Img = _context.Product_Images.SingleOrDefault(x => x.Id == id);
                if (prodcut_Img == null)
                {
                    return NotFound();
                }
                prodcut_Img.Name = product_ImgModel.Name;
                prodcut_Img.URLIMG = product_ImgModel.URLIMG;
                prodcut_Img.IdProduct = product_ImgModel.IdProduct;
                
                

                _context.SaveChanges();
                return Ok(prodcut_Img);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var prodcut_Img = _context.Product_Images.SingleOrDefault(x => x.Id == id);
                if (prodcut_Img == null)
                {
                    return NotFound();
                }
                _context.Remove(prodcut_Img);
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
