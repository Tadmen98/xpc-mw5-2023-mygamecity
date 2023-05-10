using MyGameCity.DAL.DTO;

namespace MyGameCity.DAL.Entities;

public record GameEntity : EntityBase
{
    public GameEntity()
    {

    }

    public GameEntity(GameDTO game)
    {
        Id = game.Id;
        Title = game.Title;
        ImagePath = game.ImagePath;
        Description = game.Description;
        Price = game.Price;
        Weight = game.Weight;
        NumberInStock = game.NumberInStock;
        //Category = game.Category;
        //Developer = game.Developer;
    }

    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Weight { get; set; }
    public int NumberInStock { get; set; }
    public List<CategoryEntity> Category { get; set; }
    public DeveloperEntity Developer { get; set; }
    public List<ReviewEntity> Reviews { get; set; }

}
