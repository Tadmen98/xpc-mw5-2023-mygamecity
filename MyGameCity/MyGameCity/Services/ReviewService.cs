using Bogus;
using MyGameCity.DataModel;

namespace MyGameCity.Services
{
    public class ReviewService
    {
        public static Review review;

        public static Review CreateReview()
        {
            var reviewFaker = new Faker<Review>()
               .RuleFor(x => x.Stars, f => f.Random.Number(0, 5))
               .RuleFor(x => x.Description, f => f.Random.Word())
               .RuleFor(x => x.Title, f => f.Random.Word());
            return review = reviewFaker.Generate();
        }
    }
}
