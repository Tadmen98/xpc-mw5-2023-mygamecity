namespace MyGameCity.DAL.Entities;

public record GameEntity : EntityBase
{
    public required string Name { get; init; }
    public int Image { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public int Weight { get; set; }
    public int NumberInStock { get; set; }
    public CategoryEntity Category { get; set; }
    public ManufacturerEntity Developer { get; set; }
    public ICollection<ReviewEntity> Reviews { get; set; }

}
