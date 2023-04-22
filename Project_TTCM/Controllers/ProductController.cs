using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Project_TTCM.Controllers
{
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
        public IActionResult CreateProduct(ProductModel productModel)
        {
            try
            {
                var product = new tblProduct
                {
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Notes = productModel.Notes,
                    Images = productModel.Images,
                    IdCategory = productModel.IdCategory,
                    Content = productModel.Content,
                    Price = productModel.Price,
                    Quatity = productModel.Quatity,
                    SLUG = productModel.SLUG,
                    META_TITLE = productModel.META_TITLE,
                    META_DESCRIPTION = productModel.META_DESCRIPTION,
                    META_KEYWORD = productModel.META_KEYWORD,
                    CREATED_DATE = productModel.CREATED_DATE,
                    CREATED_BY = productModel.CREATED_BY,
                    ISDELETE = productModel.ISDELETE,
                    ISACTIVE = productModel.ISACTIVE,
                };
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
                product.Images = productModel.Images;
                product.IdCategory = productModel.IdCategory;
                product.Content = productModel.Content;
                product.Price = productModel.Price;
                product.Quatity = productModel.Quatity;
                product.SLUG = productModel.SLUG;
                product.META_TITLE = productModel.META_TITLE;
                product.META_DESCRIPTION = productModel.META_DESCRIPTION;
                product.META_KEYWORD = productModel.META_KEYWORD;
                product.CREATED_DATE = productModel.CREATED_DATE;
                product.CREATED_BY = productModel.CREATED_BY;
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
