using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System;
using System.Linq;

namespace Project_TTCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDBContext _context;

        public CategoryController(MyDBContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetALl()
        {
            var listCategory = _context.Categories.ToList();
            return Ok(listCategory);
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var Category = _context.Categories.SingleOrDefault(x => x.Id == id);
            if(Category == null)
            {
                return BadRequest();
            }
            return Ok(Category);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel categoryModel)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryModel.Name,
                    Notes = categoryModel.Notes,
                    ICON = categoryModel.ICON,
                    SLUG = categoryModel.SLUG,
                    META_TITLE = categoryModel.META_TITLE,
                    META_DESCRIPTION = categoryModel.META_DESCRIPTION,
                    META_KEYWORD = categoryModel.META_KEYWORD,
                    CREATED_DATE = DateTime.Now,
                    CREATED_BY = categoryModel.CREATED_BY,
                    ISDELETE = categoryModel.ISDELETE,
                    ISACTIVE = categoryModel.ISACTIVE,

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
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutById(int id, CategoryModel categoryModel) {
            try
            {
                var category = _context.Categories.SingleOrDefault(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                category.Name = categoryModel.Name;
                category.Notes = categoryModel.Notes;
                category.ICON = categoryModel.ICON;
                category.SLUG = categoryModel.SLUG;
                category.META_TITLE = categoryModel.META_TITLE;
                category.META_DESCRIPTION = categoryModel.META_DESCRIPTION;
                category.META_KEYWORD = categoryModel.META_KEYWORD;
                category.CREATED_DATE = categoryModel.CREATED_DATE;
                category.CREATED_BY = categoryModel.CREATED_BY;
                category.ISDELETE = categoryModel.ISDELETE;
                category.ISACTIVE = categoryModel.ISACTIVE;
                _context.SaveChanges();
                return Ok(category);
            }
            catch { return BadRequest(); } 


        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(x => x.Id == id);
                if(category == null)
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
