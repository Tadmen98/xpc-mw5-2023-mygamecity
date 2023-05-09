using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record CategoryEntity: EntityBase
{
    public string Name { get; set; }
    //public List<GameEntity> Games { get; set; }
}
