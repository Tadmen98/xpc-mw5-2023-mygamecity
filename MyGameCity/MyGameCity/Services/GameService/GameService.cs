using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Data;
using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DataModel;

namespace MyGameCity.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;
        public GameService(DataContext context)
        {
            _context = context;
        }
        public GameEntity AddGame(GameDTO game_dto)
        {
            List<CategoryEntity> categories = _context.Categories.Where(c => game_dto.CategoryIds.Contains(c.Id)).ToList();
            var developer = _context.Categories.Where(c => c.Id == game_dto.Id).First();
            
            //var game = new GameEntity(game_dto) {Category = categories, };
            //_context.Review.Add(review);
            //_context.SaveChanges();
            var gam = new GameEntity() { Title="sdfsd"};
            return gam;
        }

        public GameEntity DeleteGame(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<GameEntity> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public GameEntity GetGameById(Guid id)
        {
            var game = _context.Game.Where(c => c.Id == id).First();
            return game;
        }

        public GameEntity UpdateGame(GameDTO game)
        {
            throw new NotImplementedException();
        }
    }
}
