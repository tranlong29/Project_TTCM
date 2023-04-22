using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Project_TTCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MyDBContext _context;

        public CustomerController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var ListCustomer = _context.Orders_Details.ToList();
            return Ok(ListCustomer);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return BadRequest();
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult CreateOrderDetail(CustomerDTO customerDTO)
        {
            try
            {
                var orderDetail = new Customer
                {
                    Name = customerDTO.Name,
                    Username = customerDTO.Username,
                    Password = customerDTO.Password,
                    Email = customerDTO.Email,
                    Phone = customerDTO.Phone,
                    Address = customerDTO.Address,
                    Created_Date = DateTime.Now,
                    IsAction = customerDTO.IsAction,
                    Admin = customerDTO.Admin,

                };
                _context.Add(orderDetail);
                _context.SaveChanges();
                return Ok(orderDetail);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, CustomerDTO customerDTO)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
                if (customer == null)
                {
                    return NotFound();
                }
                customer.Name = customerDTO.Name;
                customer.Username = customerDTO.Username;
                customer.Password = customerDTO.Password;
                customer.Email = customerDTO.Email;
                customer.Phone = customerDTO.Phone;
                customer.Address = customerDTO.Address;
                customer.Created_Date = DateTime.Now;
                customer.IsAction = customerDTO.IsAction;
                customer.Admin = customerDTO.Admin;

                _context.SaveChanges();
                return Ok(customer);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

                if (customer == null)
                {
                    return NotFound();
                }
                _context.Remove(customer);
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
