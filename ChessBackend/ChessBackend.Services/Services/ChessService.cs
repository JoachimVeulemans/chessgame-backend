using System.Collections.Generic;

namespace ChessBackend.Services.Services
{
    public class ChessService : IChessService
    {
        public IList<ChessGame.Src.ChessGame> ChessGames { get; set; }
        public void StartGame()
        {
            
        }
    }
}