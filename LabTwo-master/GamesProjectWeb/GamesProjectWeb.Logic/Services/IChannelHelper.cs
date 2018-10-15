using GamesProjectWeb.Logic.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesProjectWeb.Logic.Services
{
    public interface IChannelHelper
    {
        Task<Channel> GetChannelWithGamesAsync(string source);

        Task<IEnumerable<Game>> GetGamesAsync(string source);
    }
}
