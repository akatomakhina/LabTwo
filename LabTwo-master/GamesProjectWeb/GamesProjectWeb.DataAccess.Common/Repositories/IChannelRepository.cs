﻿using GamesProjectWeb.DataAccess.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesProjectWeb.DataAccess.Common.Repositories
{
    public interface IChannelRepository : IDisposable
    {
        Task<DbChannel> AddChannelAsync(DbChannel channel);

        Task<DbChannel> DeleteChannelAsync(DbChannel channel);

        Task<IEnumerable<DbChannel>> GetChannelAsync();

        Task<DbChannel> GetChannelByIdAsync(int id);
    }
}
