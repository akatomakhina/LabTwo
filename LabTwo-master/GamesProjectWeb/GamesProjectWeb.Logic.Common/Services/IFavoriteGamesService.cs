using GamesProjectWeb.Logic.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesProjectWeb.Logic.Common.Services
{
    public interface IFavoriteGamesService
    {
        Task<FavoriteGames> AddFavoriteGameAsync(int userId, int gameId);

        Task<IEnumerable<FavoriteGames>> GetFavoriteGamesForUserAsync(int userId);

        Task<Game> GetGameFromFavoriteGames(int favoriteGamesItemId);

        Task RemoveFavoriteGameAsync(int favoriteGamesItemId);
    }
}
