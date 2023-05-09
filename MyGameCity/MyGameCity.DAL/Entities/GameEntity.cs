  namespace MyGameCity.DAL.Entities;

public record GameEntity : EntityBase
{
    public required string Name { get; init; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public int Weight { get; set; }
    public int NumberInStock { get; set; }
    public List<CategoryEntity> Category { get; set; }
    //public ManufacturerEntity Developer { get; set; }
    //public ManufacturerEntity Publisher { get; set; }
    public List<ReviewEntity> Reviews { get; set; }

}
