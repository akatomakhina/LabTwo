using System.Collections.Generic;

namespace GamesProjectWeb.Logic.Common.Models
{
    public class User
    {
        public int Id { get; set; }

        public virtual ICollection<FavoriteGames> FavoriteGames { get; set; }
    }
}
