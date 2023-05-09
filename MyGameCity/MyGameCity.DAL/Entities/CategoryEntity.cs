using MyGameCity.DAL.DTO;

namespace MyGameCity.DAL.Entities;

public record CategoryEntity: EntityBase
{
    CategoryEntity() { }
    public CategoryEntity(CategoryDTO category)
    {
        Name = category.Name;
    }
    public string Name { get; set; }
    public List<GameEntity> Games { get; set; }
}
