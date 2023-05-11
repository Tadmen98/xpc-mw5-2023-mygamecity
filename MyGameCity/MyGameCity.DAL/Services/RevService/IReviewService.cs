using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
//using MyGameCity.DataModel;

namespace MyGameCity.DAL.Services.RevService
{
    public interface IReviewService
    {
        Task<ReviewEntity> GetReviewById(Guid id);

        Task<List<ReviewEntity>> GetbyGameId(Guid game_id);
        //ReviewEntity GetGameById(Guid id);

        Task<ReviewEntity> AddReview(ReviewDTO review);

        Task<ReviewEntity> UpdateReview(ReviewDTO review);

        Task<ReviewEntity> DeleteReview(Guid id);
    }
}
