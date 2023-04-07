using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Entities;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        //private static List<CategoryEntity> categories = new List<CategoryEntity> {
        //        new CategoryEntity
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "My name"
        //        }
        //    };

        //TODO: replace with service and interface
        //TODO: after that do not forget to register interface
        [HttpGet]
        public async Task<ActionResult<List<CategoryEntity>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryEntity>> GetSingleCategory(Guid id)
        {
            //var category = categories.Find(c => c.Id == id);
            var category = await _context.Categories.FindAsync(id);
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
            //categories.Add(category);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryEntity>> UpdateCategory(Guid id, CategoryEntity updated_category)
        {
            //var category = categories.Find(c => c.Id == id);
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("No category of that id");
            }
            category.Name = updated_category.Name;

            await _context.SaveChangesAsync();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryEntity>> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound("No category of that id");
            }
            //categories.Remove(category);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
