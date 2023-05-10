using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DataModel;

namespace MyGameCity.Services.RevService
{
    public interface IReviewService
    {
        List<ReviewEntity> GetAllReviews();

        List<ReviewEntity> GetbyGameId(Guid game_id);
        //ReviewEntity GetGameById(Guid id);

        ReviewEntity AddReview(ReviewDTO review);

        ReviewEntity UpdateReview(ReviewDTO review);

        ReviewEntity DeleteReview(Guid id);
    }
}
