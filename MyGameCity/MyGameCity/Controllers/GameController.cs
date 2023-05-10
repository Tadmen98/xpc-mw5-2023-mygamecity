using Bogus;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.Services;
using MyGameCity.DataModel;
using MyGameCity.Services.GameService;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
            // TODO: implement all functions using new game
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<GameEntity>>> GetbyId(Guid id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
                return NotFound("Reviews not found");

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult> Create(GameDTO game)
        {
            var result = _gameService.AddGame(game);

            return Ok("review was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(Guid id, GameDTO game)
        {
            var result = _gameService.UpdateGame(game);

            return Ok("review was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            var result = _gameService.DeleteGame(id);

            if (result == null)
                return NotFound("Reviews not found");

            return Ok("Review was deleted");
        }

        //[HttpGet("GetDatabase")]
        //public ActionResult<List<Game>> GetAll() => FakeDatabaseService.ModelDatabase;

        //[HttpGet("Game by Id")]
        //public ActionResult<Game> Get(Guid id)
        //{
        //    var game = FakeDatabaseService.Get(id);
        //    if(game == null) 
        //    {
        //        return NotFound();
        //    }
        //    return game;
        //}

        //[HttpPost("Add game to database")]
        //public IActionResult Create (Game game)
        //{
        //    FakeDatabaseService.Add(game);
        //    return NoContent();
        //}

        //[HttpPut("Update existing game")]
        //public IActionResult Update(Game game)
        //{
        //    var existingGame = FakeDatabaseService.Get(game.Id);
        //    if(existingGame is null) 
        //    {
        //        return NotFound();
        //    }
        //    FakeDatabaseService.Update(game);
        //    return NoContent();
        //}

        //[HttpDelete("Delete game from database")]
        //public IActionResult Delete(Guid id)
        //{
        //    var game = FakeDatabaseService.Get(id);

        //    if(game is null)
        //    {
        //        return NotFound();
        //    }
        //    FakeDatabaseService.Delete(id);
        //    return NoContent();
        //}
    }
}
