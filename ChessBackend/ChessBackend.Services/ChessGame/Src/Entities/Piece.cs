using ChessBackend.Services.ChessGame.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public abstract class Piece
    {
        public string Position { get; set; }
        public int Value { get; set; }
        public ChessPiece Type { get; set; }
        public Color Color { get; set; }

        public Piece(Color color, ChessPiece type, int value)
        {
            Color = color;
            Type = type;
            Value = value;
        }

        public virtual string GetPGN()
        {
            return Type.ToString()[0] + "";
        }
    }
}
