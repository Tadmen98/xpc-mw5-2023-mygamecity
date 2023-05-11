using Bogus.DataSets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DAL.Exceptions;
using MyGameCity.DAL.QueryObjects;
using MyGameCity.DAL.QueryObjects.Filters;
//using MyGameCity.DataModel;
using MyGameCity.DAL.Services;
using MyGameCity.DAL.Services.DevService;

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
            try
            {
                var developer = _developerService.GetDeveloperById(id);
                return Ok(developer);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            StatusCode(500);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperEntity>>> GetAllDevelopers()
        {
            var developer = _developerService.GetAllDevelopers();
            //if (developer == null)
            //    return NotFound("Reviews not found");

            return Ok(developer);
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<DeveloperEntity>>> GetFilteredDevelopers(DeveloperFilter filter)
        {
            var developer = _getDeveloperFilterQuery.Execute(filter);
            //if (developer == null)
            //    return NotFound("Games not found");

            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDeveloper(DeveloperDTO developer)
        {
            try
            {
                var result = _developerService.AddDeveloper(developer);
                return Ok("review was created");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeveloper(Guid id, DeveloperDTO developer)
        {
            try
            {
                var result = _developerService.UpdateDeveloper(developer);
                return Ok("Developer was updated");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeveloper(Guid id)
        {
            try
            {
                var result = _developerService.DeleteDeveloper(id);
                return Ok("Developer was deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
