using Castle.DynamicProxy;
using GamesProjectWeb.Logic.Common.Services;
using GamesProjectWeb.Logic.Logging;
using GamesProjectWeb.Logic.Services;
using SimpleInjector;
using SimpleInjector.Packaging;
using GameValidationIntercepter = GamesProjectWeb.Logic.Validator.ValidatorInterceptor;
using GamesProjectWeb.Logic.Services.PageParser;
using GamesProjectWeb.Logic.Common.Models;
using FluentValidation;
using GamesProjectWeb.Logic.Validator;
using GamesProjectWeb.DataAccess.Common.Repositories;
using GamesProjectWeb.DataAccess.Repositories;

namespace GamesProjectWeb.Logic
{
    public class InjectorPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterGamesServices(container);
        }

        private void RegisterGamesServices(Container container)
        {
            container.Register(() =>
                new ProxyGenerator().CreateInterfaceProxyWithTargetInterface<IGameService>(
                    container.GetInstance<GameService>(),
                    container.GetInstance<GameValidationIntercepter>(),
                    container.GetInstance<NLogInterceptor>()
                    ));
            container.Register(() =>
                    new ProxyGenerator().CreateInterfaceProxyWithTargetInterface<IChannelService>(
                        container.GetInstance<ChannelService>(),
                        container.GetInstance<GameValidationIntercepter>(),
                        container.GetInstance<NLogInterceptor>()
                        ));

            container.Register<IChannelHelper, ChannelHelper>();
            container.Register<IUserService, UserService>();
            container.Register<IFavoriteGamesService, FavoriteGamesService>();
            container.Register<IParseService, ParseService>();
            container.Register<AbstractValidator<LinkRequest>, LinkRequestValidator>();
            container.Register<IChannelRepository, ChannelDbRepository>();
            container.Register<IFavoriteGamesRepository, FavoriteGamesDbRepository>();
            container.Register<IUserRepository, UserDbRepository>();
            container.Register<IGameRepository, GameDbRepository>();
        }
    }
}
