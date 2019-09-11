using ChessBackend.Data.DataEntities;
using ChessBackend.Entities.ChessGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Services
{
    public class ChessService : IChessService
    {
        public IList<ChessGame> ChessGames { get; set; }

        public ChessService()
        {
            ChessGames = new List<ChessGame>();
        }
        public ChessGame GetChessGame(User player, string id)
        {
            return ChessGames.Where(c => c.Id == id && (c.WhitePlayer.Id.Equals(player.Id) || c.BlackPlayer.Id.Equals(id))).FirstOrDefault();
        }

        public string StartGame(User WhitePlayer, User BlackPlayer)
        {
            var chessGame = new ChessGame(WhitePlayer, BlackPlayer);
            ChessGames.Add(chessGame);

            return chessGame.Id;
        }
    }
}
