using MyGameCity.DataModel;

namespace MyGameCity.Services.RevService
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        Review GetGameById(Guid id);

        Review AddGame(Review review);

        Review UpdateGame(Review review);

        Review DeleteGame(Guid id);
    }
}
