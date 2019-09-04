using System.ComponentModel.DataAnnotations;

namespace ChessBackend.Entities
{
    public class Game
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public string WhiteElo { get; set; }
        [Required]
        public string BlackElo { get; set; }
        [Required]
        public string Eco { get; set; }
        [Required]
        public string Moves { get; set; }

        public string WhitePlayerId { get; set; }
        public User WhitePlayer { get; set; }
        public string BlackPlayerId { get; set; }
        public User BlackPlayer { get; set; }
    }
}
