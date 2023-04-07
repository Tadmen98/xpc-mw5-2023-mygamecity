using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.DataTransferObjects;
using MyGameCity.DAL.Entities;

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
            var games = await _context.Game
                //.Include(c => c.Category)
                //.Include(c => c.Reviews)
                .ToListAsync();
            return Ok(games);
        }

        [HttpPost]
        public async Task<ActionResult<List<GameEntity>>> AddCategory(CategoryGameDto category_game)
        {
            var game = await _context.Game
                .Where(c => c.Id == category_game.GameId)
                .Include(c => c.Category)
                .FirstOrDefaultAsync();
            if (game == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(category_game.CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            //if (game.Category == null)
            //{
            //    game.Category = new List<CategoryEntity>();
            //}
            game.Category.Add(category);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
