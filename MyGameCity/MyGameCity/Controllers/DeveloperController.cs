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
        private readonly ILogger<DeveloperController> _logger;
        public DeveloperController(IDeveloperService develper_service, GetDeveloperFilterQuery getDeveloperFilterQuery, ILogger<DeveloperController> logger)
        {
            _developerService = develper_service;
            _getDeveloperFilterQuery = getDeveloperFilterQuery;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DeveloperDTO>>> GetbyId(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Developer/{id} GET");
            try
            {
                var developer = await _developerService.GetDeveloperById(id);
                var developer_dto = new DeveloperDTO(developer);
                return Ok(developer_dto);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<DeveloperDTO>>> GetAllDevelopers()
        {
            _logger.LogInformation("Run endpoint /api/Developer GET");
            var developers = await _developerService.GetAllDevelopers();
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
            _logger.LogInformation("Run endpoint /api/Developer/Query POST");
            var developer = await _getDeveloperFilterQuery.Execute(filter);

            return Ok(developer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDeveloper(DeveloperDTO developer)
        {
            _logger.LogInformation("Run endpoint /api/Developer POST");
            try
            {
                var result = await _developerService.AddDeveloper(developer);
                return Ok("review was created");
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
            catch (AlreadyExistException ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDeveloper(DeveloperDTO developer)
        {
            _logger.LogInformation("Run endpoint /api/Developer PUT");
            try
            {
                var result = await _developerService.UpdateDeveloper(developer);
                return Ok("Developer was updated");
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeveloper(Guid id)
        {
            _logger.LogInformation("Run endpoint /api/Developer DELETE");
            try
            {
                var result = await _developerService.DeleteDeveloper(id);
                return Ok("Developer was deleted");
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
