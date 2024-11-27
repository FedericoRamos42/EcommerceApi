using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetwithDetails(int id)
        {
            var order = _orderService.GetOrderWithDetails(id);
            return Ok(order);
        }

        [HttpGet("GetOrders")]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var orderList = _orderService.GetAllOrders();
            return Ok(orderList);
        }

        [HttpPost]
        public ActionResult Post(RequestCreateOrder request)
        {
            _orderService.CreateOrder(request);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id) 
        {
            _orderService.CanceledOrder(id);
            return NoContent();
        }


    }
}
