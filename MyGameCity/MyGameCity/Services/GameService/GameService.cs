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
        public GameEntity AddGame(GameDTO game)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public GameEntity UpdateGame(GameDTO game)
        {
            throw new NotImplementedException();
        }
    }
}
