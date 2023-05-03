using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DataModel;
using MyGameCity.Services;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        [HttpGet("All developers")]
        public ActionResult<List<Developer>> GetAll() => DeveloperService.DeveloperList;
        [HttpGet("Developer and their games")]
        public ActionResult<Developer> Get(string title)
        {
            var publisher = DeveloperService.Get(title);
            if (publisher == null)
            {
                return NotFound();
            }
            return publisher;
        }
        [HttpPost("Create new developer")]
        public IActionResult Create(Developer developer)
        {
            DeveloperService.CreateDeveloper(developer);
            
            return NoContent();
        }
        [HttpDelete("Delete Developer")]
        public IActionResult Delete(string title) 
        {
            var developer = DeveloperService.Get(title);
            if (developer is null)
            {
                return NotFound();
            }
            DeveloperService.DeleteDeveloper(developer);
            return NoContent();
        }
        [HttpPut("Update Developer")]
        public IActionResult Update(Developer developer) 
        {
            var existingGame = DeveloperService.Get(developer.Title);
            if (existingGame is null)
            {
                return NotFound();
            }
            DeveloperService.Update(developer);
            return NoContent();
        }
    }
}
