using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DataModel;

namespace MyGameCity.Services.CatService
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
            var category = new CategoryEntity(category_dto);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public CategoryEntity DeleteCategory(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
                return null;

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
            var category = _context.Categories.Where(c => c.Id == id).First();
            return category;
        }

        public CategoryEntity UpdateCategory(CategoryDTO category_dto)
        {
            var category = _context.Categories.Find(category_dto.Id);
            if (category == null)
                return null;
            category.Id = category_dto.Id;
            category.Name = category_dto.Name;

            _context.SaveChanges();
            return category;
        }
    }
}
