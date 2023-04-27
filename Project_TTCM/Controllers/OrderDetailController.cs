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
    public class OrderDetailController : ControllerBase
    {
        private readonly MyDBContext _context;

        public OrderDetailController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var ListOrderDetail = _context.Orders_Details.ToList();
            return Ok(ListOrderDetail);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var orderDetail = _context.Orders_Details.SingleOrDefault(x => x.Id == id);
            if (orderDetail == null)
            {
                return BadRequest();
            }
            return Ok(orderDetail);
        }
        [HttpPost]
        public IActionResult CreateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            try
            {
                var orderDetail = new Orders_Detail
                {
                    IdOrder = orderDetailDTO.IdOrder,
                    IdProduct =orderDetailDTO.IdProduct,
                    Price = orderDetailDTO.Price,
                    Qty = orderDetailDTO.Qty,
                    Total = orderDetailDTO.Total,
                    Return_Qty = orderDetailDTO.Return_Qty
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
        public IActionResult PutById(int id, OrderDetailDTO orderDetailDTO)
        {
            try
            {
                var orderDetail = _context.Orders_Details.SingleOrDefault(x => x.Id == id);
                if (orderDetail == null)
                {
                    return NotFound();
                }
                orderDetail.IdOrder = orderDetailDTO.IdOrder;
                orderDetail.IdProduct = orderDetailDTO.IdProduct;
                orderDetail.Price = orderDetailDTO.Price;
                orderDetail.Qty = orderDetailDTO.Qty;
                orderDetail.Total = orderDetailDTO.Total;
                orderDetailDTO.Return_Qty = orderDetailDTO.Return_Qty;


                _context.SaveChanges();
                return Ok(orderDetail);
            }
            catch { return BadRequest(); }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var orderDetail = _context.Orders_Details.SingleOrDefault(x => x.Id == id);

                if (orderDetail == null)
                {
                    return NotFound();
                }
                _context.Remove(orderDetail);
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
