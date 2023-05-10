using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
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
        public DeveloperEntity AddDeveloper(DeveloperDTO developer)
        {
            throw new NotImplementedException();
        }

        public DeveloperEntity DeleteDeveloper(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<DeveloperEntity> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public DeveloperEntity GetDeveloperById(Guid id)
        {
            throw new NotImplementedException();
        }

        public DeveloperEntity UpdateDeveloper(DeveloperDTO developer)
        {
            throw new NotImplementedException();
        }
    }
}
