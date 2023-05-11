using MyGameCity.DAL.DTO;
using MyGameCity.DAL.Entities;

namespace MyGameCity.DAL.Services.GameService
{
    public interface IGameService
    {
        Task<List<GameEntity>> GetAllGames();
        Task<GameEntity> GetGameById(Guid id);

        Task<GameEntity> AddGame(GameDTO game_dto);

        Task<GameEntity> UpdateGame(GameDTO game_dto);

        Task<GameEntity> DeleteGame(Guid id);
    }
}
