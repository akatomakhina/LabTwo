using GamesProjectWeb.DataAccess.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesProjectWeb.DataAccess.Common.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<DbUser> AddUserAsync(DbUser user);

        Task<DbUser> DeleteUserAsync(DbUser user);

        Task<DbUser> GetUserByIdAsync(int id);

        Task<IEnumerable<DbUser>> GetAllUsersAsync();
    }
}
