using MyGameCity.DAL.DTO;

namespace MyGameCity.DAL.Entities;

public record CategoryEntity : EntityBase
{
    public CategoryEntity() { }
    public CategoryEntity(CategoryDTO category)
    {
        Id = category.Id;
        Name = category.Name;
    }
    public string Name { get; set; }
    public List<GameEntity> Games { get; set; }
}
