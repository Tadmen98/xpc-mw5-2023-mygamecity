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
    }
}
