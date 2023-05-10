using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.QueryObjects.Filters;
using MyGameCity.DAL.QueryObjects;
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
        private readonly GetReviewFilterQuery _getReviewFilterQuery;

        public ReviewController(IReviewService reviewService, GetReviewFilterQuery getReviewFilterQuery)
        {
            _reviewService = reviewService;
            _getReviewFilterQuery = getReviewFilterQuery;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewEntity>> GetReviewById(Guid id)
        {
            var reviews = _reviewService.GetReviewById(id);
            if (reviews == null)
                return NotFound("Reviews not found");

            return Ok(reviews);
            //return Ok();
        }

        [HttpGet("bygame/{game_id}")]
        public async Task<ActionResult<List<ReviewEntity>>> GetbyGameId(Guid game_id)
        {
            var reviews = _reviewService.GetbyGameId(game_id);
            if (reviews == null)
                return NotFound("Reviews not found");

            return Ok(reviews);
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<GameEntity>>> GetFilteredGames(ReviewFilter filter)
        {
            var review = _getReviewFilterQuery.Execute(filter);
            if (review == null)
                return NotFound("Games not found");

            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(ReviewDTO review)
        {
            var result = _reviewService.AddReview(review);

            return Ok("review was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(Guid id, ReviewDTO review)
        {
            var result = _reviewService.UpdateReview(review);

            return Ok("review was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            var result = _reviewService.DeleteReview(id);

            if (result == null)
                return NotFound("Reviews not found");

            return Ok("Review was deleted");
        }
    }
}
