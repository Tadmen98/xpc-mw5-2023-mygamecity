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
        [HttpGet("GetDatabase")]
        public ActionResult<List<Games>> GetAll() => 
        // todo-maintability why to use this via static class and not DI?
        FakeDatabaseService.ModelDatabase;
        
        [HttpGet("Game by Id")]
        // todo-other add response types
        // https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0#asynchronous-action
        public ActionResult<Games> Get(Guid id)
        {
            var game = FakeDatabaseService.Get(id);
            if(game == null) 
            {
                return NotFound();
            }
            return game;
        }

        [HttpPost("Add game to database")]
        // todo-maintability why IActionResult? you lost swagger docs with this interface 
        // create POCO object, try to avoid anonymous classes
        public ActionResult<Guid> Create (Games game)
        {
            FakeDatabaseService.Add(game);
            return CreatedAtAction(nameof(Get), game.Id);
        }

        [HttpPut("Update existing game")]
        public IActionResult Update(Guid id,Games game)
        {
            // todo-maintability why to send id && model with id?
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
