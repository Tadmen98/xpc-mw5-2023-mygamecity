using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Services.CatService;
using MyGameCity.DAL.Services.GameService;

namespace MyGameCity.Controllers
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

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CategoryEntity>>> GetCategoryById(Guid id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound("Controller not found");

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAllCategories()
        {
            var category = _categoryService.GetAllCategories();
            if (category == null)
                return NotFound("Controller not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDTO category)
        {
            var result = _categoryService.AddCategory(category);

            return Ok("Controller was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, CategoryDTO category)
        {
            var result = _categoryService.UpdateCategory(category);

            return Ok("Controller was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var result = _categoryService.DeleteCategory(id);

            if (result == null)
                return NotFound("Controller not found");

            return Ok("Controller was deleted");
        }
    }
}
