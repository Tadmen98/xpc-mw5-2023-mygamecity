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

        public CategoryEntity AddCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public CategoryEntity DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryEntity> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public CategoryEntity GetCategoryById(Guid id)
        {
            var category = _context.Categories.Where(c => c.Id == id).First();
            return category;
        }

        public CategoryEntity UpdateCategory(CategoryDTO category)
        {
            throw new NotImplementedException();
        }
    }
}
