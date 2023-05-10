using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DataModel;

namespace MyGameCity.Services.RevService
{
    public class ReviewService : IReviewService
    {
        private readonly DataContext _context;
        public ReviewService(DataContext context)
        {
            _context = context;
        }
        public ReviewEntity AddReview(ReviewDTO review_dto)
        {
            var game = _context.Game.Where(c => c.Id == review_dto.GameId).First();
            var review = new ReviewEntity(review_dto) {Game = game};
            _context.Review.Add(review);
            _context.SaveChanges();
            return review;
        }

        public ReviewEntity DeleteGame(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ReviewEntity> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public List<ReviewEntity> GetbyGameId(Guid game_id)
        {
            var reviews = _context.Review.Where(c => c.Game.Id == game_id).ToList();
            return reviews;
        }

        //public Review GetGameById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public Review UpdateGame(ReviewEntity review)
        {
            throw new NotImplementedException();
        }

        ReviewEntity IReviewService.UpdateGame(ReviewEntity review)
        {
            throw new NotImplementedException();
        }
    }
}
