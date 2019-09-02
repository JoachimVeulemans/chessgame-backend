using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class Square
    {
        private Piece _chessPiece;
        public int Row { get; set; }
        public int Column { get; set; }
        public string Position { get; set; }
        public Piece ChessPiece
        {
            get
            {
                return _chessPiece;
            }
            set
            {
                _chessPiece = value;

                if(value == null)
                {
                    HasChessPiece = false;
                }
                else
                {
                    HasChessPiece = true;
                }
            }
        }

        public bool HasChessPiece { get; set; }

        public Square(int row, int column)
        {
            Row = row;
            Column = column;
            Position = Utilities.GetPositionInPGN(row, column);
        }

    }
}
