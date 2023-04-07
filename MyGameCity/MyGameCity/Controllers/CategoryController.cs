using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.Entities;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<CategoryEntity> categories = new List<CategoryEntity> {
                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "My name"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAllCategories()
        {
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryEntity>> GetSingleCategory(Guid id)
        {
            var category = categories.Find(c => c.Id == id);
            if (category == null)
            {
                return NotFound("No category of that id");
            }
            return Ok(category);
        }

        [HttpPost("{category_name}")]
        public async Task<ActionResult<CategoryEntity>> AddCategory(string category_name)
        {
            var category = new CategoryEntity(){Id = Guid.NewGuid(), Name = category_name };
            categories.Add(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryEntity>> UpdateCategory(Guid id, CategoryEntity updated_category)
        {
            var category = categories.Find(c => c.Id == id);
            if (category == null)
            {
                return NotFound("No category of that id");
            }
            category.Name = updated_category.Name;
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryEntity>> DeleteCategory(Guid id)
        {
            var category = categories.Find(c => c.Id == id);
            if (category == null)
            {
                return NotFound("No category of that id");
            }
            categories.Remove(category);
            return Ok(categories);
        }
    }
}
