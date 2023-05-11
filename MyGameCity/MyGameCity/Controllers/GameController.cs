using Bogus;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.Services;
using MyGameCity.DataModel;
using MyGameCity.DAL.Services.GameService;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.QueryObjects;
using MyGameCity.DAL.QueryObjects.Filters;
using Microsoft.EntityFrameworkCore.Query;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly GetGamesFilterQuery _getGameFilterQuery;
        //private readonly IQuery<GameEntity, GameFilter> _getGameFilterQuery;

        public GameController(IGameService gameService, GetGamesFilterQuery getGameFilterQuery)
        {
            _gameService = gameService;
            _getGameFilterQuery = getGameFilterQuery;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameEntity>> GetGameById(Guid id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
                return NotFound("Games not found");

            return Ok(game);
        }

        [HttpGet("all")]
        public async Task<ActionResult<GameEntity>> GetAllGames()
        {
            var games = _gameService.GetAllGames();
            if (games == null)
                return NotFound("Games not found");

            return Ok(games);
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<GameEntity>>> GetFilteredGames(GameFilter filter)
        {
            var games = _getGameFilterQuery.Execute(filter);
            if (games == null)
                return NotFound("Games not found");
            Console.WriteLine("Called query");
            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGame(GameDTO game)
        {
            var result = _gameService.AddGame(game);

            return Ok("Games was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(Guid id, GameDTO game)
        {
            var result = _gameService.UpdateGame(game);

            return Ok("Games was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(Guid id)
        {
            var result = _gameService.DeleteGame(id);

            if (result == null)
                return NotFound("Games not found");

            return Ok("Games was deleted");
        }
    }
}
