using MyGameCity.DAL.Data;
using MyGameCity.DataModel;

namespace MyGameCity.Services.DevService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly DataContext _context;

        public DeveloperService(DataContext context)
        {
            _context = context;
        }
        public Developer AddCategory(Developer developer)
        {
            throw new NotImplementedException();
        }

        public Developer DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Developer> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Developer GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Developer UpdateCategory(Developer developer)
        {
            throw new NotImplementedException();
        }
    }
}
