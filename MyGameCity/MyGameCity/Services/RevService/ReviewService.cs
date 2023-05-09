using MyGameCity.DAL.Data;
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
        public Review AddGame(Review review)
        {
            throw new NotImplementedException();
        }

        public Review DeleteGame(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public Review GetGameById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Review UpdateGame(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
