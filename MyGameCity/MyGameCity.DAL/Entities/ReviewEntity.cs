namespace MyGameCity.DAL.Entities;

public record ReviewEntity: EntityBase
{
    public int Stars { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
