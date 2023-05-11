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
        public async Task<ActionResult<List<CategoryDTO>>> GetCategoryById(Guid id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                var category_dto = new CategoryDTO(category);
                return Ok(category_dto);
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
            var categoríes = await _categoryService.GetAllCategories();
            List<CategoryDTO> categories_dtos = new List<CategoryDTO>();
            foreach (var category in categoríes)
            {
                var category_dto = new CategoryDTO(category);
                categories_dtos.Add(category_dto);
            }

            return Ok(categories_dtos);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDTO category)
        {
            try
            {
                var result = await _categoryService.AddCategory(category);
                return Ok("Category was created");
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

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(CategoryDTO category)
        {
            try
            {
                var result = await _categoryService.UpdateCategory(category);
                return Ok("Category was updated");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            try
            {
                var result = await _categoryService.DeleteCategory(id);
                return Ok("Category was deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
