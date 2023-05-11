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
        protected readonly ILogger<GameController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<GameController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
            // TODO: implement all functions using new game
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CategoryEntity>>> GetbyId(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Category/{Id} GET");
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                _logger.LogTrace("Category was not found");
                return NotFound("Category was not found");
            }
            _logger.LogTrace("Category was found");
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAllCategories()
        {
            _logger.LogInformation("Run endpoint /api/Category GET");
            var category = _categoryService.GetAllCategories();
            if (category == null)
            {
                _logger.LogTrace("Category was not found");
                return NotFound("Category not found");
            }
            _logger.LogTrace("Categories were found");
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDTO category)
        {
            _logger.LogInformation("Run endpoint /api/Category POST");
            var result = _categoryService.AddCategory(category);

            _logger.LogTrace("Category was created");
            return Ok("Category was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, CategoryDTO category)
        {
            _logger.LogInformation("Run endpoint /api/Category/{Id} PUT");
            var result = _categoryService.UpdateCategory(category);

            _logger.LogTrace("Category was updated");
            return Ok("Category was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Category/{Id} DELETE");
            var result = _categoryService.DeleteCategory(id);

            if (result == null)
            {
                _logger.LogTrace("Category was not found");
                return NotFound("Categroy was not found");
            }

            _logger.LogTrace("Category was deleted");
            return Ok("Categroy was deleted");
        }
    }
}
