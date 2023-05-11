using Bogus;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.Services;
using MyGameCity.Services.GameService;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.DTO;
using Bogus.DataSets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        protected readonly ILogger<GameController> _logger;
        public GameController(IGameService gameService,ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
            // TODO: implement all functions using new game
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameEntity>> GetbyId(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/game/{Id} GET");

            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                _logger.LogTrace("Game was not found");
                return NotFound("Game not found");
            }
            _logger.LogTrace("Game was found");
            return Ok(game);
        }

        [HttpGet]
        public async Task<ActionResult<GameEntity>> GetAllGames()
        {
            _logger.LogInformation("Run endpoint /api/game GET");

            var games = _gameService.GetAllGames();
            if (games == null)
            {
                _logger.LogTrace("Database is empty");
                return NotFound("Games not found");
            }

            _logger.LogTrace("Got all games from database");

            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGame(GameDTO game)
        {
            _logger.LogInformation("Run endpoint /api/game POST");

            var result = _gameService.AddGame(game);

            _logger.LogTrace("Added new game to database with Id {id}",game.Id);

            return Ok("Game was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(Guid id, GameDTO game)
        {
            _logger.LogInformation("Run endpoint /api/game/{Id} PUT");

            var result = _gameService.UpdateGame(game);

            _logger.LogTrace("Updated game in database with Id {id}", game.Id);

            return Ok("Game was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/game/{Id} DELETE");

            var result = _gameService.DeleteGame(id);

            if (result == null)
            {
                _logger.LogTrace("Game in database with Id {id} was not found",id);
                return NotFound("Game not found");
            }
            _logger.LogTrace("Deleted game in database with Id {id}", id);
            return Ok("Game was deleted");
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
