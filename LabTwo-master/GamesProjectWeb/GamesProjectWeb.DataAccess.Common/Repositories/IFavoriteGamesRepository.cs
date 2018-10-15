using GamesProjectWeb.DataAccess.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesProjectWeb.DataAccess.Common.Repositories
{
    public interface IFavoriteGamesRepository : IDisposable
    {
        Task<DbFavoriteGames> AddFavoriteGamesAsync(DbFavoriteGames news);

        Task<IEnumerable<DbFavoriteGames>> GetAllFavoriteGamesAsync();

        Task<DbFavoriteGames> GetFavoriteGamesByIdAsync(int id);

        Task<IEnumerable<DbFavoriteGames>> GetFavoriteGamesForUserAsync(int userId);

        Task<DbFavoriteGames> RemoveFavoriteGamesAsync(DbFavoriteGames news);
    }
}
