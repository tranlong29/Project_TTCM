using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_TTCM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDBContext _context;

        public CategoryController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetALl()
        {
            var listCategory = _context.Categories.ToList();
            return Ok(listCategory);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Category = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (Category == null)
            {
                return BadRequest();
            }
            return Ok(Category);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel categoryModel)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryModel.Name,
                };
                

                _context.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, CategoryModel categoryModel)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                category.Name = categoryModel.Name;
                _context.SaveChanges();
                return Ok(category);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                _context.Remove(category);
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
