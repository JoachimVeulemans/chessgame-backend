﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ChessBackend.Data.DataEntities
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

        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string Language { get; set; }

        public IList<Game> GamesAsWhite { get; set; }
        public IList<Game> GamesAsBlack { get; set; }
    }
}
