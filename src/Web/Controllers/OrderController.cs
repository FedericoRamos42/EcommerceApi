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
        public async Task<ActionResult<OrderDto>> GetwithDetails(int id)
        {
            var order = await _orderService.GetOrderWithDetails(id);
            return Ok(order);
        }

        [HttpGet("GetOrders")]1
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var orderList = await _orderService.GetAllOrders();
            return Ok(orderList);
        }

        [HttpPost]
        public async Task<ActionResult> Post(RequestCreateOrder request)
        {
            await _orderService.CreateOrder(request);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id)
        {
            await _orderService.CanceledOrder(id);
            return NoContent();
        }

    }
}
