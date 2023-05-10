using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.QueryObjects;
using MyGameCity.DAL.QueryObjects.Filters;
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
        private readonly GetDeveloperFilterQuery _getDeveloperFilterQuery;

        public DeveloperController(IDeveloperService develper_service, GetDeveloperFilterQuery getDeveloperFilterQuery)
        {
            _developerService = develper_service;
            _getDeveloperFilterQuery = getDeveloperFilterQuery;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DeveloperEntity>>> GetbyId(Guid id)
        {
            var developer = _developerService.GetDeveloperById(id);
            if (developer == null)
                return NotFound("Reviews not found");

            return Ok(developer);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperEntity>>> GetAllDevelopers()
        {
            var developer = _developerService.GetAllDevelopers();
            if (developer == null)
                return NotFound("Reviews not found");

            return Ok(developer);
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<DeveloperEntity>>> GetFilteredDevelopers(DeveloperFilter filter)
        {
            var developer = _getDeveloperFilterQuery.Execute(filter);
            if (developer == null)
                return NotFound("Games not found");

            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDeveloper(DeveloperDTO developer)
        {
            var result = _developerService.AddDeveloper(developer);

            return Ok("review was created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeveloper(Guid id, DeveloperDTO developer)
        {
            var result = _developerService.UpdateDeveloper(developer);

            return Ok("review was updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeveloper(Guid id)
        {
            var result = _developerService.DeleteDeveloper(id);

            if (result == null)
                return NotFound("Reviews not found");

            return Ok("Review was deleted");
        }
    }
}
