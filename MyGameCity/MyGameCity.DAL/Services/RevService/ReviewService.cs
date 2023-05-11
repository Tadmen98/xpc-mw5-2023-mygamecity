using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Exceptions;
//using MyGameCity.DataModel;

namespace MyGameCity.DAL.Services.RevService
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
            var game = _context.Game.Where(c => c.Id == review_dto.GameId).FirstOrDefault();
            if (game == null)
            {
                throw new NotFoundException($"Game {review_dto.GameId} was not found");
            }
            var review_check = _context.Review.Where(c => c.Id == review_dto.Id).FirstOrDefault();
            if (review_check != null)
            {
                throw new AlreadyExistException($"Review {review_dto.GameId} already exists");
            }

            var review = new ReviewEntity(review_dto) {Game = game};
            _context.Review.Add(review);
            _context.SaveChanges();
            return review;
        }

        public ReviewEntity DeleteReview(Guid id)
        {
            var review = _context.Review.Find(id);
            if (review is null)
            {
                throw new NotFoundException($"Review {id} was not found");
            }

            _context.Review.Remove(review);
            _context.SaveChanges();
            return review;
        }

        public ReviewEntity GetReviewById(Guid id)
        {
            var review = _context.Review.Where(c => c.Id == id).FirstOrDefault();
            if (review is null)
            {
                throw new NotFoundException($"Review {id} was not found");
            }
            return review;
        }

        public List<ReviewEntity> GetbyGameId(Guid game_id)
        {
            //TODO: make game check
            //var game = _context.Game.Where(c => c.Id == game_id).FirstOrDefault();
            //if (game == null)
            //{
            //    throw new NotFoundException($"Game {game_id} was not found");
            //}
            var reviews = _context.Review.Where(c => c.Game.Id == game_id).ToList();
            return reviews;
            //TODO: remove list
        }

        //public Review GetGameById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public ReviewEntity UpdateReview(ReviewDTO review_dto)
        {
            var review = _context.Review.Find(review_dto.Id);
            if (review == null)
            {
                throw new NotFoundException($"Review {review_dto.Id} was not found");
            }
            review.Title = review_dto.Title;
            review.Description = review_dto.Description;
            review.StarsCount = review_dto.StarsCount;

            _context.SaveChanges();
            return review;
        }

        //ReviewEntity IReviewService.UpdateReview(ReviewEntity review)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
