using Bogus;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.Services.GameService;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.QueryObjects;
using MyGameCity.DAL.QueryObjects.Filters;
using Microsoft.EntityFrameworkCore.Query;
using MyGameCity.DAL.Exceptions;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly GetGamesFilterQuery _getGameFilterQuery;
        private readonly ILogger<GameController> _logger;


        public GameController(IGameService gameService, GetGamesFilterQuery getGameFilterQuery, ILogger<GameController> logger)
        {
            _gameService = gameService;
            _getGameFilterQuery = getGameFilterQuery;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponseDTO>> GetGameById(Guid id)
        {
            try
            {
                var game = await _gameService.GetGameById(id);
                var game_dto = new GameResponseDTO(game);
                return Ok(game_dto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<GameResponseDTO>> GetAllGames()
        {
            var games = await _gameService.GetAllGames();
            List<GameResponseDTO> game_dtos = new List<GameResponseDTO>();
            foreach (var game in games)
            {
                var game_dto = new GameResponseDTO(game);
                game_dtos.Add(game_dto);
            }

            return Ok(game_dtos);
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<GameEntity>>> GetFilteredGames(GameFilter filter)
        {
            var games = await _getGameFilterQuery.Execute(filter);

            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGame(GameDTO game)
        {
            try
            {
                var result = await _gameService.AddGame(game);
                return Ok("Games was created");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame(GameDTO game)
        {
            try
            {
                var result = await _gameService.UpdateGame(game);
                return Ok("Games was updated");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(Guid id)
        {
            try
            {
                var result = await _gameService.DeleteGame(id);
                return Ok("Games was deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
