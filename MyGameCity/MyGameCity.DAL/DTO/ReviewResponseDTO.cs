using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.DTO;

public record ReviewResponseDTO : EntityBase
{
    public ReviewResponseDTO() { }

    public ReviewResponseDTO(ReviewEntity review)
    {
        Id = review.Id;
        StarsCount = review.StarsCount;
        Title = review.Title;
        Description = review.Description;
    }
    public int StarsCount { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
