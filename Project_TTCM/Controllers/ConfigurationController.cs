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
    public class ConfigurationController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ConfigurationController(MyDBContext context) { 
            _context = context;
        }
        [HttpGet]
        public IActionResult GetALl()
        {
            var listConfg = _context.Configurations.ToList();
            return Ok(listConfg);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Confg = _context.Configurations.SingleOrDefault(x => x.Id == id);
            if (Confg == null)
            {
                return BadRequest();
            }
            return Ok(Confg);
        }

        [HttpPost]
        public IActionResult CreateConfg( ConfigurationModel configurationModel)
        {
            try
            {
                var confg = new Configuration
                {
                    Name = configurationModel.Name,
                    Notes = configurationModel.Notes,
                    ISDELETE = configurationModel.ISDELETE,
                    ISACTIVE = configurationModel.ISACTIVE,
                };
                _context.Add(confg);
                _context.SaveChanges();
                return Ok(confg);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, ConfigurationModel configurationModel)
        {
            try
            {
                var confg = _context.Configurations.SingleOrDefault(x => x.Id == id);
                if (confg == null)
                {
                    return NotFound();
                }
                confg.Name = confg.Name;
                confg.Notes = configurationModel.Notes;
                confg.ISDELETE = configurationModel.ISDELETE;
                confg.ISACTIVE = configurationModel.ISACTIVE;
                _context.SaveChanges();
                return Ok(confg);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var confg = _context.Configurations.SingleOrDefault(x => x.Id == id);

                if (confg == null)
                {
                    return NotFound();
                }
                _context.Remove(confg);
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
