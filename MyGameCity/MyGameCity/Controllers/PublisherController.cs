using Microsoft.AspNetCore.Mvc;
using MyGameCity.DataModel;
using MyGameCity.Services;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        [HttpGet("Publisher and their Games")]
        public ActionResult<Publisher> Get(string title)
        {
            var publisher = PublisherService.Get(title);
            if (publisher == null)
            {
                return NotFound();
            }
            return publisher;
        }
    }
}
