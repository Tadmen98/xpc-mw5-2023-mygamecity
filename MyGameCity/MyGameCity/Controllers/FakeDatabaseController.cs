using MyGameCity.Services;
using Microsoft.AspNetCore.Mvc;
using MyGameCity.DataModel;
using Bogus;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDatabaseController : ControllerBase
    {
        [HttpGet("Create fake databse")]
        public void CreatDatabase() => FakeDatabaseService.CreateDatabase();
    }
}
