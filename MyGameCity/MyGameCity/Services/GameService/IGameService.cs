using MyGameCity.DataModel;

namespace MyGameCity.Services.GameService
{
    public interface IGameService
    {
        List<Game> GetAllGames();
        Game GetGameById(Guid id);

        Game AddGame(Game game);

        Game UpdateGame(Game game);

        Game DeleteGame(Guid id);
    }
}
