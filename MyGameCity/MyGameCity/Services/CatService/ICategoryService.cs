using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;

namespace MyGameCity.Services.CatService
{
    public interface ICategoryService
    {
        List<CategoryEntity> GetAllCategories();
        CategoryEntity GetCategoryById(Guid id);

        CategoryEntity AddCategory(CategoryDTO category);

        CategoryEntity UpdateCategory(CategoryDTO category);

        CategoryEntity DeleteCategory(Guid id);
    }
}
