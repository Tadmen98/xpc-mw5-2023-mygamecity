using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record ReviewEntity: EntityBase
{
    public int StarsCount { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //public GameEntity Game { get; set; }
}
