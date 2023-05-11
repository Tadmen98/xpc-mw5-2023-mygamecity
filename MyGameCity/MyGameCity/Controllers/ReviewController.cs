using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
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
        protected readonly ILogger<GameController> _logger;
        public ReviewController(IReviewService reviewService, ILogger<GameController> logger)
        {
            _reviewService = reviewService;
            _logger = logger;
            // TODO: implement all functions using new game
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewEntity>> GetReviewById(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Review/{Id} GET");

            var reviews = _reviewService.GetReviewById(id);
            if (reviews == null)
            {
                _logger.LogTrace("Review was not found");
                return NotFound("Reviews not found");
            }
            _logger.LogTrace("Review was not found");
            return Ok(reviews);
            //return Ok();
        }

        [HttpGet("bygame/{game_id}")]
        public async Task<ActionResult<List<ReviewEntity>>> GetbyGameId(Guid game_id)
        {
            _logger.LogInformation("Run endpoint /api/Review/bygame/{game_id} GET");
            var reviews = _reviewService.GetbyGameId(game_id);
            if (reviews == null)
            {
                _logger.LogTrace("Game was not found");
                return NotFound("Game was not found");
            }
            _logger.LogTrace("Game was not found");
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ReviewDTO review)
        {
            _logger.LogInformation("Run endpoint /api/Review POST");
            var result = _reviewService.AddReview(review);

            _logger.LogTrace("Game was created");
            return Ok("review was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(Guid id, ReviewDTO review)
        {
            _logger.LogInformation("Run endpoint /api/Review/{Id} PUT");
            var result = _reviewService.UpdateReview(review);

            _logger.LogTrace("Review was updated");
            return Ok("review was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Review/{Id} DELETE");
            var result = _reviewService.DeleteReview(id);

            if (result == null)
            {
                _logger.LogTrace("Review was not found");
                return NotFound("Reviews was not found");
            }
            _logger.LogTrace("Review was deleted");
            return Ok("Review was deleted");
        }
    }
}
