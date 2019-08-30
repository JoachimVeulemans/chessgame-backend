using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Services.ChessGame.Src.Enums;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class King : Piece
    {
        public King(Color color) : base(color, ChessPiece.KING, 99) { }
    }
}
