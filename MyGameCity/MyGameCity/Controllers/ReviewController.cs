using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.DataTransferObjects;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DataContext _context;

        public ReviewController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewEntity>>> Get(Guid gameId)
        {
            var reviews = await _context.Review.Where(c => c.Id == gameId).ToListAsync();

            return reviews;
        }

        [HttpPost]
        public async Task<ActionResult<List<ReviewEntity>>> Create(ReviewDto review)
        {
            var game = await _context.Game.FindAsync(review.GameId); 
            if (game == null)
                return NotFound();

            var new_review = new ReviewEntity
            {
                Id = review.Id,
                Title = review.Title,
                Description = review.Description,
                StarsCount = review.StarsCount,
                Game = game
            };
            // TODO: check whether already in database
            // TODO: maybe remove Id from Dto
            _context.Review.Add(new_review);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
