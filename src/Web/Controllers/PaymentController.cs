using Application.Dtos;
using Application.Services;
using MercadoPago.Resource.Preference;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentProviderService _provider;
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(PaymentProviderService provider,ILogger<PaymentController> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        [HttpPost("{id}")]
        public async Task<string> CreatePayment(int id)
        {
            var redirectUrl = await _provider.CreatePayment(id);
           return redirectUrl.SandboxInitPoint;
        }

        [HttpPost("webhook")]
        public IActionResult Notification([FromBody] NotificationDto body)
        {
            var response = _provider.GetStatusNotification(body.Data.Id);
            return Ok(response);
        }
    }
}
