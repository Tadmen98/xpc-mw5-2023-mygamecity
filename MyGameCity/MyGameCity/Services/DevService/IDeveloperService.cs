using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;

namespace MyGameCity.Services.DevService
{
    public interface IDeveloperService
    {
        List<DeveloperEntity> GetAllDevelopers();
        DeveloperEntity GetDeveloperById(Guid id);

        DeveloperEntity AddDeveloper(DeveloperDTO developer);

        DeveloperEntity UpdateDeveloper(DeveloperDTO developer);

        DeveloperEntity DeleteDeveloper(Guid id);
    }
}
