using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
//using MyGameCity.DataModel;

namespace MyGameCity.DAL.Services.DevService
{
    public interface IDeveloperService
    {
        Task<List<DeveloperEntity>> GetAllDevelopers();
        Task<DeveloperEntity> GetDeveloperById(Guid id);

        Task<DeveloperEntity> AddDeveloper(DeveloperDTO developer);

        Task<DeveloperEntity> UpdateDeveloper(DeveloperDTO developer);

        Task<DeveloperEntity> DeleteDeveloper(Guid id);
    }
}
