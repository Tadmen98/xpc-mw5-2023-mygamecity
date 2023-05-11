using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Exceptions;
//using MyGameCity.DataModel;

namespace MyGameCity.DAL.Services.CatService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<CategoryEntity> AddCategory(CategoryDTO category_dto)
        {
            var category_check = await _context.Categories.Where(c => c.Id == category_dto.Id).FirstOrDefaultAsync();
            if (category_check != null)
            {
                throw new AlreadyExistException($"Category {category_dto.Id} already exists");
            }
            var category = new CategoryEntity(category_dto);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryEntity> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
            {
                throw new NotFoundException($"Category {id} was not found");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<List<CategoryEntity>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<CategoryEntity> GetCategoryById(Guid id)
        {
            var category = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (category is null)
            {
                throw new NotFoundException($"Category {id} was not found");
            }
            return category;
        }

        public async Task<CategoryEntity> UpdateCategory(CategoryDTO category_dto)
        {
            var category = await _context.Categories.FindAsync(category_dto.Id);
            if (category == null)
            {
                throw new NotFoundException($"Category {category_dto.Id} was not found");
            }
            category.Id = category_dto.Id;
            category.Name = category_dto.Name;

            await _context.SaveChangesAsync();
            return category;
        }
    }
}
