using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.QueryObjects.Filters;
using MyGameCity.DAL.QueryObjects;
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
        private readonly ILogger<ReviewController> _logger;
        public ReviewController(IReviewService reviewService, GetReviewFilterQuery getReviewFilterQuery, ILogger<ReviewController> logger)
        {
            _reviewService = reviewService;
            _getReviewFilterQuery = getReviewFilterQuery;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewResponseDTO>> GetReviewById(Guid id)
        {
            try
            {
                var reviews = await _reviewService.GetReviewById(id);
                var review_dto = new ReviewResponseDTO(reviews);
                return Ok(review_dto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message.ToString());
            }
        }

        [HttpGet("bygame/{game_id}")]
        public async Task<ActionResult<List<ReviewResponseDTO>>> GetbyGameId(Guid game_id)
        {
            try
            {
                var reviews = await _reviewService.GetbyGameId(game_id);
                List<ReviewResponseDTO> review_dtos = new List<ReviewResponseDTO>();
                foreach (var review in reviews)
                {
                    var creview_dto = new ReviewResponseDTO(review);
                    review_dtos.Add(creview_dto);
                }
                return Ok(review_dtos);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<GameEntity>>> GetFilteredGames(ReviewFilter filter)
        {
            var review = await _getReviewFilterQuery.Execute(filter);

            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(ReviewDTO review)
        {
            try
            {
                var result = await _reviewService.AddReview(review);
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
        }

        [HttpPut]
        public async Task<ActionResult> UpdateReview(ReviewDTO review)
        {
            try
            {
                var result = await _reviewService.UpdateReview(review);
                return Ok("Review was updated");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            try
            {
                var result = await _reviewService.DeleteReview(id);
                return Ok("Review was deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
