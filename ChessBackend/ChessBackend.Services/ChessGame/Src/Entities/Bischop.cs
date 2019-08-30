using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Services.ChessGame.Src.Enums;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class Bischop : Piece
    {
        public Bischop(Color color) : base(color, ChessPiece.BISHOP, 3) { }
    }
}
