using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record CategoryDTO : EntityBase
{
    public CategoryDTO() { }

    public CategoryDTO(CategoryEntity category)
    {
        Id = category.Id;
        Name = category.Name;
    }
    public string Name { get; set; }
}
