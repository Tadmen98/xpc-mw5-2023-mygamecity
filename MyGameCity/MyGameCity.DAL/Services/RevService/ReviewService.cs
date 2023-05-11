using Microsoft.EntityFrameworkCore;
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
        public async Task<ReviewEntity> AddReview(ReviewDTO review_dto)
        {
            var game = await _context.Game.Where(c => c.Id == review_dto.GameId).FirstOrDefaultAsync();
            if (game == null)
            {
                throw new NotFoundException($"Game {review_dto.GameId} was not found");
            }
            var review_check = await _context.Review.Where(c => c.Id == review_dto.Id).FirstOrDefaultAsync();
            if (review_check != null)
            {
                throw new AlreadyExistException($"Review {review_dto.GameId} already exists");
            }

            var review = new ReviewEntity(review_dto) {Game = game};
            await _context.Review.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<ReviewEntity> DeleteReview(Guid id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review is null)
            {
                throw new NotFoundException($"Review {id} was not found");
            }

            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<ReviewEntity> GetReviewById(Guid id)
        {
            var review = await _context.Review.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (review is null)
            {
                throw new NotFoundException($"Review {id} was not found");
            }
            return review;
        }

        public async Task<List<ReviewEntity>> GetbyGameId(Guid game_id)
        {
            //TODO: make game check
            //var game = _context.Game.Where(c => c.Id == game_id).FirstOrDefault();
            //if (game == null)
            //{
            //    throw new NotFoundException($"Game {game_id} was not found");
            //}
            var reviews = await _context.Review.Where(c => c.Game.Id == game_id).ToListAsync();
            return reviews;
            //TODO: remove list
        }

        //public Review GetGameById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ReviewEntity> UpdateReview(ReviewDTO review_dto)
        {
            var review = _context.Review.Find(review_dto.Id);
            if (review == null)
            {
                throw new NotFoundException($"Review {review_dto.Id} was not found");
            }
            review.Title = review_dto.Title;
            review.Description = review_dto.Description;
            review.StarsCount = review_dto.StarsCount;

            await _context.SaveChangesAsync();
            return review;
        }

        //ReviewEntity IReviewService.UpdateReview(ReviewEntity review)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
