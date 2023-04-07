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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
