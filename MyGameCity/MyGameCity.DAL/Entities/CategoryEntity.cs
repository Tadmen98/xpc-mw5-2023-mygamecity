namespace MyGameCity.DAL.Entities;

public record CategoryEntity: EntityBase
{
    public string Name { get; set; }
    public List<GameEntity> Games { get; set; }
}
