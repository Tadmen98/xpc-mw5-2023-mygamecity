using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DataModel;
using MyGameCity.Services;
using MyGameCity.Services.DevService;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService develper_service)
        {
            _developerService = develper_service;
            // TODO: implement all functions using new game
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<GameEntity>>> GetbyId(Guid id)
        {
            var developer = _developerService.GetDeveloperById(id);
            if (developer == null)
                return NotFound("Reviews not found");

            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeveloperDTO developer)
        {
            var result = _developerService.AddDeveloper(developer);

            return Ok("review was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(Guid id, DeveloperDTO developer)
        {
            var result = _developerService.UpdateDeveloper(developer);

            return Ok("review was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            var result = _developerService.DeleteDeveloper(id);

            if (result == null)
                return NotFound("Reviews not found");

            return Ok("Review was deleted");
        }
        //[HttpGet("All developers")]
        //public ActionResult<List<Developer>> GetAll() => DeveloperService.DeveloperList;
        //[HttpGet("Developer and their games")]
        //public ActionResult<Developer> Get(string title)
        //{
        //    var publisher = DeveloperService.Get(title);
        //    if (publisher == null)
        //    {
        //        return NotFound();
        //    }
        //    return publisher;
        //}
        //[HttpPost("Create new developer")]
        //public IActionResult Create(Developer developer)
        //{
        //    DeveloperService.CreateDeveloper(developer);

        //    return NoContent();
        //}
        //[HttpDelete("Delete Developer")]
        //public IActionResult Delete(string title) 
        //{
        //    var developer = DeveloperService.Get(title);
        //    if (developer is null)
        //    {
        //        return NotFound();
        //    }
        //    DeveloperService.DeleteDeveloper(developer);
        //    return NoContent();
        //}
        //[HttpPut("Update Developer")]
        //public IActionResult Update(Developer developer) 
        //{
        //    var existingGame = DeveloperService.Get(developer.Title);
        //    if (existingGame is null)
        //    {
        //        return NotFound();
        //    }
        //    DeveloperService.Update(developer);
        //    return NoContent();
        //}
    }
}
