using System.ComponentModel.DataAnnotations;

namespace ChessBackend.Data.DataEntities
{
    public class FamousGame
    {
        [Required]
        public int FamousGameId { get; set; }
        public string Event { get; set; }
        public string Site { get; set; }
        public string Date { get; set; }
        public string Round { get; set; }
        public string WhitePlayer { get; set; }
        public string BlackPlayer { get; set; }
        public string Result { get; set; }
        public string WhiteElo { get; set; }
        public string BlackElo { get; set; }
        public string Eco { get; set; }
        public string Moves { get; set; }
    }
}
