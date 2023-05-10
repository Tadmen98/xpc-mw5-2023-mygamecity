using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DataModel;
using MyGameCity.Services.CatService;
using MyGameCity.Services.GameService;
using MyGameCity.Services.RevService;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
            // TODO: implement all functions using new game
        }

        [HttpGet("{game_id}")]
        public async Task<ActionResult<List<GameEntity>>> GetbyGameId(Guid game_id)
        {
            var reviews = _reviewService.GetbyGameId(game_id);
            if (reviews == null)
                return NotFound("Reviews not found");

            return Ok(reviews);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ReviewDTO review)
        {
            var result = _reviewService.AddReview(review);

            return Ok("review was created");
        }
    }
}
