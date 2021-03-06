﻿using System;
using System.Collections.Generic;

namespace GamesProjectWeb.DataAccess.Common.Models
{
    public class DbChannel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string LinkRSS { get; set; }

        public DateTime? LastModified { get; set; }

        public virtual ICollection<DbGame> Games { get; set; }
    }
}
