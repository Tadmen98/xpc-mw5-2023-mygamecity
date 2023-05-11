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

        public CategoryEntity AddCategory(CategoryDTO category_dto)
        {
            var category_check = _context.Categories.Where(c => c.Id == category_dto.Id).FirstOrDefault();
            if (category_check != null)
            {
                throw new AlreadyExistException($"Category {category_dto.Id} already exists");
            }
            var category = new CategoryEntity(category_dto);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public CategoryEntity DeleteCategory(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
            {
                throw new NotFoundException($"Category {id} was not found");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public List<CategoryEntity> GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public CategoryEntity GetCategoryById(Guid id)
        {
            var category = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category is null)
            {
                throw new NotFoundException($"Category {id} was not found");
            }
            return category;
        }

        public CategoryEntity UpdateCategory(CategoryDTO category_dto)
        {
            var category = _context.Categories.Find(category_dto.Id);
            if (category == null)
            {
                throw new NotFoundException($"Category {category_dto.Id} was not found");
            }
            category.Id = category_dto.Id;
            category.Name = category_dto.Name;

            _context.SaveChanges();
            return category;
        }
    }
}
