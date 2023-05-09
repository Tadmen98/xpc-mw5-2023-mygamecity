using MyGameCity.DAL.Data;
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

        public Category AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Category DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Category UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
