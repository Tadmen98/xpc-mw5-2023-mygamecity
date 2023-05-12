using MyGameCity.DAL.DTO;

namespace MyGameCity.DAL.Entities;

public record ReviewEntity : EntityBase
{
    public ReviewEntity() { }

    public ReviewEntity(ReviewDTO review)
    {
        Id = review.Id;
        StarsCount = review.StarsCount;
        Title = review.Title;
        Description = review.Description;
        GameId = review.GameId;
    }

    public int StarsCount { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public GameEntity Game { get; set; }
    public Guid GameId { get; set; }

}
