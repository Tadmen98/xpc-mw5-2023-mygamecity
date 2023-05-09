using MyGameCity.DataModel;

namespace MyGameCity.Services.CatService
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(Guid id);

        Category AddCategory(Category category);

        Category UpdateCategory(Category category);

        Category DeleteCategory(Guid id);
    }
}
