using ChessBackend.Data.DataEntities;
using ChessBackend.Entities.ChessGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBackend.Services
{
    public interface IChessService
    {
        string StartGame(User whitePlayer, User blackPlayer);
        ChessGame GetChessGame(User player, string chessGameId);
        IList<string> GetPossiblePositions(User player, string chessGameId, string position);
    }
}
