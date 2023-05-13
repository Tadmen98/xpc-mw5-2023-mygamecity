using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Exceptions;
using MyGameCity.DAL.Services.CatService;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        protected readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        //DFSDKMVS KMV SKLVMS





       

        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAllCategories()
        {
            _logger.LogInformation("Run endpoint /api/Category GET");
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
            _logger.LogInformation("Run endpoint /api/Category POST");
            try
            {
                var result = await _categoryService.AddCategory(category);
                return Ok("Category was created");
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(CategoryDTO category)
        {
            _logger.LogInformation("Run endpoint /api/Category PUT");
            try
            {
                var result = await _categoryService.UpdateCategory(category);
                return Ok("Category was updated");
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Category/{id} DELETE");
            try
            {
                var result = await _categoryService.DeleteCategory(id);
                return Ok("Category was deleted");
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
