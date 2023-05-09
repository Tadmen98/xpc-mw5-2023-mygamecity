using MyGameCity.DataModel;

namespace MyGameCity.Services.DevService
{
    public interface IDeveloperService
    {
        List<Developer> GetAllCategories();
        Developer GetCategoryById(Guid id);

        Developer AddCategory(Developer developer);

        Developer UpdateCategory(Developer developer);

        Developer DeleteCategory(Guid id);
    }
}
