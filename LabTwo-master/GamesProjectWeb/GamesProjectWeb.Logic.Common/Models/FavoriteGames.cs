using System;

namespace GamesProjectWeb.Logic.Common.Models
{
    public class FavoriteGames
    {
        public int Id { get; set; }

        public DateTime? LastModified { get; set; }

        public int UserId { get; set; }

        public int GameId { get; set; }
    }
}
