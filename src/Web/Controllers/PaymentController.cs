using Application.Services;
using MercadoPago.Resource.Preference;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentProviderService _provider;

        public PaymentController(PaymentProviderService provider)
        {
            _provider = provider;
        }

        [HttpPost("{id}")]
        public async Task<Preference> CreatePayment(int id)
        {
            var redirectUrl = await _provider.ProccessPaymentAsync(id);
           return redirectUrl;
        }
        [HttpGet("success")]
        public IActionResult Success([FromQuery] string external_reference)
        {
           
            return Ok(new { Status = "Success", Reference = external_reference });
        }

        [HttpGet("failure")]
        public IActionResult Failure([FromQuery] string external_reference)
        {
            
            return Ok(new { Status = "Failure", Reference = external_reference });
        }
    }
}
