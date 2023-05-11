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
        public async Task<ActionResult<List<DeveloperDTO>>> GetbyId(Guid id)
        {
            try
            {
                var developer = await _developerService.GetDeveloperById(id);
                var developer_dto = new DeveloperDTO(developer);
                return Ok(developer_dto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            StatusCode(500);
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperDTO>>> GetAllDevelopers()
        {
            var developers = await _developerService.GetAllDevelopers();
            //if (developer == null)
            //    return NotFound("Reviews not found");
            List<DeveloperDTO> developer_dtos = new List<DeveloperDTO>();
            foreach (var developer in developers)
            {
                var developer_dto = new DeveloperDTO(developer);
                developer_dtos.Add(developer_dto);
            }

            return Ok(developer_dtos);
        }

        [HttpPost("Query")]
        public async Task<ActionResult<List<DeveloperEntity>>> GetFilteredDevelopers(DeveloperFilter filter)
        {
            var developer = await _getDeveloperFilterQuery.Execute(filter);
            //if (developer == null)
            //    return NotFound("Games not found");

            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDeveloper(DeveloperDTO developer)
        {
            try
            {
                var result = await _developerService.AddDeveloper(developer);
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

        [HttpPut]
        public async Task<ActionResult> UpdateDeveloper(DeveloperDTO developer)
        {
            try
            {
                var result = await _developerService.UpdateDeveloper(developer);
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
                var result = await _developerService.DeleteDeveloper(id);
                return Ok("Developer was deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
