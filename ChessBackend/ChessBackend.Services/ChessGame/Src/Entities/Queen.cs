using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Services.ChessGame.Src.Enums;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class Queen : Piece
    {
        public Queen(Color color) : base(color, ChessPiece.QUEEN, 9) { }
    }
}
