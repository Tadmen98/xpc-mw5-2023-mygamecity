using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DataContext _context;

        public ReviewController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<ReviewEntity>>> Get(Guid gameId)
        {
            var reviews = await _context.Review
                .Where(c => c.Id == gameId).ToListAsync();

            return reviews;
        }
    }
}
