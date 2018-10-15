using GamesProjectWeb.Logic.Common.Models;
using System.Threading.Tasks;

namespace GamesProjectWeb.Logic.Services.PageParser
{
    public interface IParseService
    {
        Task<Game> LoadDetailAsync(Game news);
    }
}
