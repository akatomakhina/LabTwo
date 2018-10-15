using GamesProjectWeb.Logic.Common.Models;
using System.Threading.Tasks;

namespace GamesProjectWeb.Logic.Common.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync();

        Task DeleteUserAsync(int id);
    }
}
