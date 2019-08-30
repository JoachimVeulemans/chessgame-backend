using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Services.ChessGame.Src.Enums;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class Rook : Piece
    {
        public Rook(Color color) : base(color, ChessPiece.ROOK, 5) { }
    }
}
