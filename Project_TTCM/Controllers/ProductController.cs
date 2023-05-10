using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Threading.Tasks;

namespace Project_TTCM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductController (MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetALl()
        {
            var listProdcut = _context.Products.ToList();
            return Ok(listProdcut);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (Product == null)
            {
                return BadRequest();
            }
            return Ok(Product);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductModel productModel)
        {
            try
            {
                var product = new tblProduct
                {
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Notes = productModel.Notes,
                    IdCategory = productModel.IdCategory,
                    Price = productModel.Price,
                    Quatity = productModel.Quatity,
                    ISDELETE = productModel.ISDELETE,
                    ISACTIVE = productModel.ISACTIVE,
                };
                if (productModel.fileImages.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", productModel.fileImages.FileName);
                  
                    using (var stream = System.IO.File.Create(path))
                    {
                        await productModel.fileImages.CopyToAsync(stream);
                    }
                    product.Images = "/images/" + productModel.fileImages.FileName;

                }
                else
                {
                    product.Images = "";
                }
                _context.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, ProductModel productModel)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
                product.Name = productModel.Name;
                product.Description = productModel.Description;
                product.Notes = productModel.Notes;
                product.IdCategory = productModel.IdCategory;
                product.Price = productModel.Price;
                product.Quatity = productModel.Quatity;
                product.ISDELETE = productModel.ISDELETE;
                product.ISACTIVE = productModel.ISACTIVE;
                _context.SaveChanges();
                return Ok(product);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.Id ==id);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Remove(product);
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
