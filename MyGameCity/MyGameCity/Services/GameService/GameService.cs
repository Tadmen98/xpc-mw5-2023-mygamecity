using Microsoft.EntityFrameworkCore;
using MyGameCity.DAL.Data;
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
        public Game AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public Game DeleteGame(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Game GetGameById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Game UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
