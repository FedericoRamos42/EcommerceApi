using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("AllCategories")]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories() 
        {
            var list = _categoryService.GetCategories();
            return Ok(list);
        }

        [HttpPost]
        public ActionResult CreateCategory(string nameCategory)
        {
            _categoryService.CreateCategory(nameCategory);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id) 
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
        
    }
}
