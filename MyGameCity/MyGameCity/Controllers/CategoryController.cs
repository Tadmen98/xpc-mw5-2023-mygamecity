using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.Services.CatService;
using MyGameCity.Services.GameService;

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
            // TODO: implement all functions using new game
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CategoryEntity>>> GetbyId(Guid id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound("Reviews not found");

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAllCategories()
        {
            var category = _categoryService.GetAllCategories();
            if (category == null)
                return NotFound("Reviews not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDTO category)
        {
            var result = _categoryService.AddCategory(category);

            return Ok("review was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, CategoryDTO category)
        {
            var result = _categoryService.UpdateCategory(category);

            return Ok("review was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var result = _categoryService.DeleteCategory(id);

            if (result == null)
                return NotFound("Reviews not found");

            return Ok("Review was deleted");
        }
    }
}
