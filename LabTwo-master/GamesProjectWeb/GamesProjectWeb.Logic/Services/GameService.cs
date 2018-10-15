using AutoMapper;
using GamesProjectWeb.DataAccess.Common.Models;
using GamesProjectWeb.DataAccess.Common.Repositories;
using GamesProjectWeb.Logic.Common.Exceptions;
using GamesProjectWeb.Logic.Common.Models;
using GamesProjectWeb.Logic.Common.Services;
using GamesProjectWeb.Logic.Services.PageParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesProjectWeb.Logic.Services
{
    public class GameService : IGameService
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IChannelHelper _channelHelper;
        private readonly IParseService _parseService;

        public GameService(IChannelRepository channelRepository, IGameRepository gameRepository, IChannelHelper channelHelper, IParseService parseService)
        {
            _channelRepository = channelRepository ?? throw new ArgumentNullException(nameof(channelRepository));
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _channelHelper = channelHelper ?? throw new ArgumentNullException(nameof(channelHelper));
            _parseService = parseService ?? throw new ArgumentNullException(nameof(parseService));
        }

        public async Task<Game> GetGameFromIdAsync(int channelId, int gameId)
        {
            var channel = await GetChannelAsync(channelId).ConfigureAwait(false);

            var game = await _gameRepository.GetGameByIdAsync(gameId).ConfigureAwait(false);
            if (ReferenceEquals(game, null) || game.ChannelId != channel.Id)
            {
                throw new RequestedResourceNotFoundException($"Game with id {gameId} or channel with id {channelId}");
            }

            var newsWithDetailInfo = await _parseService.LoadDetailAsync(Mapper.Map<Game>(game));

            return newsWithDetailInfo;
        }

        public async Task<IEnumerable<Game>> GetGamesByTitleAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new GamesServiceException(ErrorType.BadRequest);
            }

            var allGames = await _gameRepository.GetAllGameAsync().ConfigureAwait(false);
            var filteredGames = allGames.Where(game => game.Title != null && game.Title.Contains(title));
            return filteredGames.Select(game => Mapper.Map<Game>(game));
        }

        public async Task<IEnumerable<Game>> GetGamesFromFeedAsync(int channelId)
        {
            var channel = await GetChannelAsync(channelId).ConfigureAwait(false);
            var games = await _channelHelper.GetGamesAsync(channel.LinkRSS).ConfigureAwait(false);

            await CheckUpdatesGames(games, channelId).ConfigureAwait(false);

            var updatedChannel = await _channelRepository.GetChannelByIdAsync(channelId).ConfigureAwait(false);
            return updatedChannel.Games.Select(item => Mapper.Map<Game>(item));
        }

        public async Task RemoveGameAsync(int channelId, int gameId)
        {
            var channel = await _channelRepository.GetChannelByIdAsync(channelId).ConfigureAwait(false);
            if (ReferenceEquals(channel, null))
            {
                throw new RequestedResourceNotFoundException($"Channel with id {channelId}");
            }

            var game = channel.Games.SingleOrDefault(item => item.Id == gameId);
            if (ReferenceEquals(game, null))
            {
                throw new RequestedResourceNotFoundException($"Game with id {gameId} on channel with id {channelId}");
            }

            await _gameRepository.DeleteGameAsync(game).ConfigureAwait(false);
        }

        private async Task CheckUpdatesGames(IEnumerable<Game> games, int channelId)
        {
            var dbnewsItems = await _gameRepository.GetAllGameAsync().ConfigureAwait(false);
            foreach (var gameItem in games)
            {
                var dbItem = dbnewsItems.FirstOrDefault(dbNews => dbNews.Link == gameItem.Link);
                if (ReferenceEquals(dbItem, null))
                {
                    var itemForAdd = Mapper.Map<DbGame>(gameItem);
                    itemForAdd.ChannelId = channelId;
                    var addedItem = await _gameRepository.AddGameAsync(itemForAdd).ConfigureAwait(false);
                }
            }
        }

        private async Task<Channel> GetChannelAsync(int channelId)
        {
            var channel = await _channelRepository.GetChannelByIdAsync(channelId).ConfigureAwait(false);

            if (ReferenceEquals(channel, null))
            {
                throw new RequestedResourceNotFoundException($"Channel with id {channelId}");
            }

            return Mapper.Map<Channel>(channel);
        }
    }
}
