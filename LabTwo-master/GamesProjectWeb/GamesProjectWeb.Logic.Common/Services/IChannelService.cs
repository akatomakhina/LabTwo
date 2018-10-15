using GamesProjectWeb.Logic.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesProjectWeb.Logic.Common.Services
{
    public interface IChannelService
    {
        Task<Channel> GetOrCreateChannelAsync(LinkRequest createRequest);

        Task<IEnumerable<Channel>> GetChannels();

        Task RemoveChannelAsync(int channelId);
    }
}
