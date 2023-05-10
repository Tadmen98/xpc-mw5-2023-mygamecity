using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;
using MyGameCity.DataModel;

namespace MyGameCity.Services.GameService
{
    public interface IGameService
    {
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(Guid id);

        GameEntity AddGame(GameDTO game);

        GameEntity UpdateGame(GameDTO game);

        GameEntity DeleteGame(Guid id);
    }
}
