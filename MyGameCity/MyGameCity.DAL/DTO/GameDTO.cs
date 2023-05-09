using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record GameEntity : EntityBase
{
    public required string Title { get; init; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Weight { get; set; }
    public int NumberInStock { get; set; }
    public List<CategoryEntity> Category { get; set; }
    public List<DeveloperEntity> Developer { get; set; }
    //public List<ReviewEntity> Reviews { get; set; }

}
