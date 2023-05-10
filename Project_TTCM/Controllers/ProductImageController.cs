using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> CreateProductAsync([FromForm] ProductImgDTO product_ImgModel, IFormFile[] formFiles)
        {
            try
            {
                string pictures = "";
                var prodcut_Img = new Product_Image
                {
                    Name = product_ImgModel.Name,
                    IdProduct = product_ImgModel.IdProduct,
                };
                if (formFiles.Length > 0)
                {
                    foreach (var file in formFiles)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                        using (var stream = System.IO.File.Create(path))
                        {
                            await file.CopyToAsync(stream);
                        }
                        pictures += "/images/" + file.FileName + ";";
                    }

                    prodcut_Img.URLIMG = pictures;
                }
                else
                {
                    prodcut_Img.URLIMG = "";
                }
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
