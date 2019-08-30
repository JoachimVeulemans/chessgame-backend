using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Services.ChessGame.Src.Enums;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class Pawn : Piece
    {
        public Pawn(Color color) : base(color, ChessPiece.PAWN, 1) { }
    }
}
