﻿using Bogus;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.Services;
using MyGameCity.DataModel;
using MyGameCity.Services.GameService;

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

        [HttpGet("GetDatabase")]
        public ActionResult<List<Game>> GetAll() => FakeDatabaseService.ModelDatabase;
        
        [HttpGet("Game by Id")]
        public ActionResult<Game> Get(Guid id)
        {
            var game = FakeDatabaseService.Get(id);
            if(game == null) 
            {
                return NotFound();
            }
            return game;
        }

        [HttpPost("Add game to database")]
        public IActionResult Create (Game game)
        {
            FakeDatabaseService.Add(game);
            return NoContent();
        }

        [HttpPut("Update existing game")]
        public IActionResult Update(Game game)
        {
            var existingGame = FakeDatabaseService.Get(game.Id);
            if(existingGame is null) 
            {
                return NotFound();
            }
            FakeDatabaseService.Update(game);
            return NoContent();
        }

        [HttpDelete("Delete game from database")]
        public IActionResult Delete(Guid id)
        {
            var game = FakeDatabaseService.Get(id);

            if(game is null)
            {
                return NotFound();
            }
            FakeDatabaseService.Delete(id);
            return NoContent();
        }
    }
}