using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameControler : ControllerBase
    {
        private readonly DataContext _context;

        public GameControler(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameEntity>>>GetAllGames()
        {
            var games = await _context.Game.ToListAsync();
            return Ok(games);
        }
    }
}
