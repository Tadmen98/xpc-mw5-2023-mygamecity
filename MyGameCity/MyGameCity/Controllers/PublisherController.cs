using Microsoft.AspNetCore.Mvc;
using MyGameCity.DataModel;
using MyGameCity.Services;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        [HttpGet("All publisher")]
        public ActionResult<List<Publisher>> GetAll() => PublisherService.PublisherList;

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
        [HttpPost("Create new publisher")]
        public IActionResult Create(Publisher publisher)
        {
            PublisherService.CreatePublisher(publisher);

            return NoContent();
        }
        [HttpDelete("Delete publisher")]
        public IActionResult Delete(string title)
        {
            var developer = PublisherService.Get(title);
            if (developer is null)
            {
                return NotFound();
            }
            PublisherService.DeletePublisher(publisher);
            return NoContent();
        }
        [HttpPut("Update publisher")]
        public IActionResult Update(Publisher publisher)
        {
            var existingGame = PublisherService.Get(publisher.Title);
            if (existingGame is null)
            {
                return NotFound();
            }
            PublisherService.Update(publisher);
            return NoContent();
        }
    }
}
