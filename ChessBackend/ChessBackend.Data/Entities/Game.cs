using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Data.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string Date { get; set; }
        public User WhitePlayer { get; set; }
        public User BlackPlayer { get; set; }
        public string Result { get; set; }
        public string WhiteElo { get; set; }
        public string BlackElo { get; set; }
        public string Eco { get; set; }
        public string Moves { get; set; }
    }
}
