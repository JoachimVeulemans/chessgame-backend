using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Services.ChessGame.Src.Enums;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(color, ChessPiece.KNIGHT, 3) { }

        public override string GetPGN()
        {
            return Type.ToString()[1] + "";
        }
    }
}
