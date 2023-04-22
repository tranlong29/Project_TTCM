using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_TTCM.Datas;
using Project_TTCM.Models;
using System.Linq;
using System.Net;

namespace Project_TTCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MyDBContext _context;

        public OrderController(MyDBContext context) 
        { 
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var ListOrder = _context.Orders.ToList();
            return Ok(ListOrder);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (order == null)
            {
                return BadRequest();
            }
            return Ok(order);
        }
        [HttpPost]
        public IActionResult CreateOrder( OrderDTO orderDTO)
        {
            try
            {
                var order = new Orders
                {
                    IdOrder = orderDTO.IdOrder,
                    Orderdate = orderDTO.Orderdate,
                    IdCustomer = orderDTO.IdCustomer,
                    Total_Money = orderDTO.Total_Money,
                    Notes = orderDTO.Notes,
                    Name_Reciver = orderDTO.Name_Reciver,
                    Address = orderDTO.Address,
                    Email = orderDTO.Email,
                    Phone = orderDTO.Phone,
                    IsDelete = orderDTO.IsDelete,
                    IsAction = orderDTO.IsAction
                };
                _context.Add(order);
                _context.SaveChanges();
                return Ok(order);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutById(int id, OrderDTO orderDTO)
        {
            try
            {
                var order = _context.Orders.SingleOrDefault(x => x.Id == id);
                if (order == null)
                {
                    return NotFound();
                }
                order.IdOrder = orderDTO.IdOrder;
                order.Orderdate = orderDTO.Orderdate;
                order.IdCustomer = orderDTO.IdCustomer;
                order.Total_Money = orderDTO.Total_Money;
                order.Notes = orderDTO.Notes;
                order.Name_Reciver = orderDTO.Name_Reciver;
                order.Address = orderDTO.Address;
                order.Email = orderDTO.Email;
                order.Phone = orderDTO.Phone;
                order.IsDelete = orderDTO.IsDelete;
                order.IsAction = orderDTO.IsAction;
                _context.SaveChanges();
                return Ok(order);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var order = _context.Orders.SingleOrDefault(x => x.Id == id);

                if (order == null)
                {
                    return NotFound();
                }
                _context.Remove(order);
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
