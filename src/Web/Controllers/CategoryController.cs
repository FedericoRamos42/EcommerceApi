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
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories() 
        {
            var list = await _categoryService.GetCategories();
            return Ok(list);
        }

        [HttpPost]
        public async Task <ActionResult> CreateCategory(string nameCategory)
        {
            await _categoryService.CreateCategory(nameCategory);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id) 
        {
            await _categoryService.DeleteCategory(id);
            return NoContent();
        }
        
    }
}
