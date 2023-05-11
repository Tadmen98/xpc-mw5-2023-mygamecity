using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.Services;
using MyGameCity.Services.DevService;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        protected readonly ILogger<GameController> _logger;
        public DeveloperController(IDeveloperService develper_service, ILogger<GameController> logger)
        {
            _developerService = develper_service;
            _logger = logger;
            // TODO: implement all functions using new game
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DeveloperEntity>>> GetbyId(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Developer/{Id} GET");
            var developer = _developerService.GetDeveloperById(id);
            if (developer == null)
            {
                _logger.LogTrace("Developer was not found");
                return NotFound("Reviews not found");
            }
            _logger.LogTrace("Developer was found");
            return Ok(developer);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperEntity>>> GetAllDevelopers()
        {
            _logger.LogInformation("Run endpoint /api/Developer GET");
            var developer = _developerService.GetAllDevelopers();
            if (developer == null)
            {
                _logger.LogTrace("Developer was not found");
                return NotFound("Developer not found");
            }
            _logger.LogTrace("Developers were found");
            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeveloperDTO developer)
        {
            _logger.LogInformation("Run endpoint /api/Developer Create");
            var result = _developerService.AddDeveloper(developer);

            _logger.LogTrace("Developer was created");
            return Ok("Developer was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(Guid id, DeveloperDTO developer)
        {
            _logger.LogInformation("Run endpoint /api/Developer/{Id} PUT");
            var result = _developerService.UpdateDeveloper(developer);
            _logger.LogTrace("Developer was updated");
            return Ok("Developer was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Developer/{Id} DELETE");
            var result = _developerService.DeleteDeveloper(id);

            if (result == null)
            {
                _logger.LogTrace("Developer was not found");
                return NotFound("Developer not found");
            }
            _logger.LogTrace("Developer was deleted");
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
