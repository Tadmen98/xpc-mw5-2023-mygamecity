using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
//using MyGameCity.DataModel;

namespace MyGameCity.DAL.Services.CatService
{
    public interface ICategoryService
    {
        Task<List<CategoryEntity>> GetAllCategories();
        Task<CategoryEntity> GetCategoryById(Guid id);

        Task<CategoryEntity> AddCategory(CategoryDTO category);

        Task<CategoryEntity> UpdateCategory(CategoryDTO category);

        Task<CategoryEntity> DeleteCategory(Guid id);
    }
}
