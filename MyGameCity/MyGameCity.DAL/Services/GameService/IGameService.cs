using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.Services.GameService
{
    public interface IGameService
    {
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(Guid id);

        GameEntity AddGame(GameDTO game_dto);

        GameEntity UpdateGame(GameDTO game_dto);

        GameEntity DeleteGame(Guid id);
    }
}
