namespace GamesProjectWeb.Logic.Services.PageParser.Parser
{
    public interface IGamePageParser
    {
        string Parse(string html);

        string Host { get; }
    }
}
