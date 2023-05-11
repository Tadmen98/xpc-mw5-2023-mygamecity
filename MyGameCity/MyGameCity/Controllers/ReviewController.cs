using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.QueryObjects.Filters;
using MyGameCity.DAL.QueryObjects;
//using MyGameCity.DataModel;
using MyGameCity.DAL.Services.CatService;
using MyGameCity.DAL.Services.GameService;
using MyGameCity.DAL.Services.RevService;
using MyGameCity.DAL.Exceptions;

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
            try
            {
                var reviews = _reviewService.GetReviewById(id);
                return Ok(reviews);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message.ToString());
            }
            StatusCode(505);
        }

        [HttpGet("bygame/{game_id}")]
        public async Task<ActionResult<List<ReviewEntity>>> GetbyGameId(Guid game_id)
        {
            try
            {
                var reviews = _reviewService.GetbyGameId(game_id);
                return Ok(reviews);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            StatusCode(500);
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<GameEntity>>> GetFilteredGames(ReviewFilter filter)
        {
            var review = _getReviewFilterQuery.Execute(filter);
            //if (review == null)
                //return NotFound("Games not found");
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(ReviewDTO review)
        {
            try
            {
                var result = _reviewService.AddReview(review);
                return Ok("review was created");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(Guid id, ReviewDTO review)
        {
            try
            {
                var result = _reviewService.UpdateReview(review);
                return Ok("Review was updated");
            }
            catch (NotFoundException ex) 
            {
                return NotFound(ex.Message);
            }
            StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            try
            {
                var result = _reviewService.DeleteReview(id);
                return Ok("Review was deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
