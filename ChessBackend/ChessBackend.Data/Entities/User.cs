using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ChessBackend.Data.Entities
{
    public class User : IdentityUser
    {
        [PersonalData]
        public int Elo { get; set; }

        [PersonalData]
        public int Wins { get; set; }

        [PersonalData]
        public int Losses { get; set; }

        [PersonalData]
        public int Ties { get; set; }

        public IList<Game> GamesAsWhite { get; set; }
        public IList<Game> GamesAsBlack { get; set; }
    }
}
