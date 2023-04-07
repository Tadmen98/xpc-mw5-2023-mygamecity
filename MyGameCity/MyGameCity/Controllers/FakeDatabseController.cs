using MyGameCity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MyGameCity.DataModel;
using System.Runtime.CompilerServices;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDatabseController : ControllerBase
    {
        [HttpHead]
        public ActionResult CreatDatabase() => FakeDatabaseService.CreateDatabase();

        
    }
}
