using Application.Dtos;
using Application.Dtos.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<ProductDto>> GetProduct(int id) 
        {
            var product = await  _productService.GetById(id);
            return Ok(product);
        }

        [HttpGet("AllProducts")]
        public async Task <ActionResult<IEnumerable<ProductDto>>> GetProducts() 
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(RequestCreateProduct product) 
        {
            await _productService.CreateProduct(product);
            return NoContent();
        }

        [HttpPut("UpdateStock")]
        public async Task<ActionResult> UpdateProduct(RequestUpdateProductStock request) 
        {
            await _productService.UpdateStock(request);
            return NoContent();
        }

        [HttpDelete]
        public async Task <ActionResult> DeleteProduct(int id) 
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }


    }
}
