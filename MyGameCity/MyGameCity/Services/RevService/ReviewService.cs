using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;


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

        public ReviewEntity DeleteReview(Guid id)
        {
            var review = _context.Review.Find(id);
            if (review is null)
                return null;

            _context.Review.Remove(review);
            _context.SaveChanges();
            return review;
        }

        public ReviewEntity GetReviewById(Guid id)
        {
            var review = _context.Review.Where(c => c.Id == id).First();
            //var review = new ReviewEntity() { };
            return review;
        }

        public List<ReviewEntity> GetbyGameId(Guid game_id)
        {
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
                return null;
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
