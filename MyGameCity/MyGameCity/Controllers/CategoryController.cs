using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Exceptions;
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
            try
            {
                var category = _categoryService.GetCategoryById(id);
                return Ok(category);
            }
            catch (NotFoundException ex)
            {
                string message = ex.Message;
                return NotFound(message);
            }
            StatusCode(500);

        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAllCategories()
        {
            var category = _categoryService.GetAllCategories();
            //if (category == null)
            //    return NotFound("Controller not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDTO category)
        {
            try
            {
                var result = _categoryService.AddCategory(category);
                return Ok("Controller was created");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, CategoryDTO category)
        {
            try
            {
                var result = _categoryService.UpdateCategory(category);
                return Ok("Controller was updated");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            StatusCode(500);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            try
            {
                var result = _categoryService.DeleteCategory(id);
                return Ok("Controller was deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
