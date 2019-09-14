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
        public ChessGame GetChessGame(User player, string chessGameId)
        {
            return ChessGames.FirstOrDefault(c => c.Id == chessGameId && (c.WhitePlayer.Id.Equals(player.Id) || c.BlackPlayer.Id.Equals(chessGameId)));
        }

        public string StartGame(User WhitePlayer, User BlackPlayer)
        {
            var chessGame = new ChessGame(WhitePlayer, BlackPlayer);
            ChessGames.Add(chessGame);

            return chessGame.Id;
        }

        public IList<string> GetPossiblePositions(User player, string chessGameId, string position)
        {
            var chessGame = GetChessGame(player, chessGameId);

            return chessGame == null ? new List<string>() : chessGame.GetValidMoves(position);
        }
    }
}