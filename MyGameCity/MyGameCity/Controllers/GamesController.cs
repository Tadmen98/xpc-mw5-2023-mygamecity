using Bogus;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.Services;
using MyGameCity.DataModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // GET: api/<GamesController>
        [HttpGet("GetDatabase")]
        public ActionResult<List<Games>> GetAll() => FakeDatabaseService.ModelDatabase;
        

        // GET api/<GamesController>/5
        [HttpGet("Game by Id")]
        public ActionResult<Games> Get(Guid id)
        {
            var game = FakeDatabaseService.Get(id);
            if(game == null) 
            {
                return NotFound();
            }
            return game;
        }

        // POST api/<GamesController>
        [HttpPost("Add game to database")]
        public IActionResult Create (Games game)
        {
            FakeDatabaseService.Add(game);
            return CreatedAtAction(nameof(Get), new {id = game.Id}, game);
        }

        // PUT api/<GamesController>/5
        [HttpPut("Update existing game")]
        public IActionResult Update(Guid id,Games game)
        {
            if(id != game.Id) 
            {
                return BadRequest();
            }
            var existingGame = FakeDatabaseService.Get(id);
            if(existingGame is null) 
            {
                return NotFound();
            }
            FakeDatabaseService.Update(game);
            return NoContent();
        }

        // DELETE api/<GamesController>/5
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
