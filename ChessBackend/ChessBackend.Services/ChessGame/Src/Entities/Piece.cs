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
        public ChessPiece ChessPiece { get; set; }
        public Color Color { get; set; }

        public Piece(Color color, ChessPiece chessPiece, int value)
        {
            Color = color;
            ChessPiece = chessPiece;
            Value = value;
        }

        public virtual string GetPGN()
        {
            return this.ChessPiece.ToString()[0] + "";
        }
    }
}
