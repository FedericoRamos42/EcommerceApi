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
        public ActionResult<ProductDto> GetProduct(int id) 
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpGet("AllUsers")]
        public ActionResult<IEnumerable<ProductDto>> GetProducts() 
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult CreateProduct(RequestCreateProduct product) 
        {
            _productService.CreateProduct(product);
            return NoContent();
        }

        [HttpPut("UpdateStock")]
        public ActionResult UpdateProduct(RequestUpdateProductStock request) 
        {
            _productService.UpdateStock(request);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id) 
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }


    }
}
