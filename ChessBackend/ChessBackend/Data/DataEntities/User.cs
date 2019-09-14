using System.Collections.Generic;
using ChessBackend.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace ChessBackend.Data.DataEntities
{
    public class User : IdentityUser
    {
        public User()
        {

        }
        public User(string id, UserModel userModel)
        {
            Id = id;
            UserName = userModel.UserName;
            FirstName = userModel.FirstName;
            LastName = userModel.LastName;
            Email = userModel.Email;
            Bio = userModel.Bio;
            Language = userModel.Language;
        }

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
        [PersonalData]
        public string Bio { get; set; }

        public IList<Game> GamesAsWhite { get; set; }
        public IList<Game> GamesAsBlack { get; set; }
    }
}
