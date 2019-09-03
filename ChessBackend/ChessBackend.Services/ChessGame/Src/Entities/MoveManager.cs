using ChessBackend.Services.ChessGame.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class MoveManager
    {
        public IList<string> GetMoves(Square position)
        {
            IList<string> moveList = new List<string>();

            if (!position.HasChessPiece)
            {
                return null;
            }

            switch (position.ChessPiece.Type)
            {
                case ChessPiece.PAWN:
                    moveList = GetPawnMoves(position.Row, position.Column, position.ChessPiece);
                    break;
                case ChessPiece.KNIGHT:
                    moveList = GetKnightMoves(position.Row, position.Column, position.ChessPiece);
                    break;
                case ChessPiece.BISHOP:
                    moveList = GetBishopMoves(position.Row, position.Column, position.ChessPiece);
                    break;
                case ChessPiece.ROOK:
                    moveList = GetRookMoves(position.Row, position.Column, position.ChessPiece);
                    break;
                case ChessPiece.QUEEN:
                    moveList = GetQueenMoves(position.Row, position.Column, position.ChessPiece);
                    break;
                case ChessPiece.KING:
                    moveList = GetKingMoves(position.Row, position.Column, position.ChessPiece);
                    break;
            }

            return moveList;
        }

        private IList<string> GetKingMoves(int row, int column, Piece chessPiece)
        {
            throw new NotImplementedException();
        }

        private IList<string> GetQueenMoves(int row, int column, Piece chessPiece)
        {
            throw new NotImplementedException();
        }

        private IList<string> GetRookMoves(int row, int column, Piece chessPiece)
        {
            throw new NotImplementedException();
        }

        private IList<string> GetBishopMoves(int row, int column, Piece chessPiece)
        {
            throw new NotImplementedException();
        }

        private IList<string> GetKnightMoves(int row, int column, Piece chessPiece)
        {
            throw new NotImplementedException();
        }

        private IList<string> GetPawnMoves(int row, int column, Piece chessPiece)
        {
            var newRow = row;

            if(chessPiece.Color == Color.WHITE)
            {
                newRow -= 1;
                //moves = GetPawnMovesForWhite(row, column, chessPiece);
            }
            else
            {
                newRow += 1;
                //moves = GetPawnMovesForBlack(row, column, chessPiece);
            }

            if (row >= 0 && row < 8)
            {
                return new List<string>()
                {
                    Utilities.GetPositionInPGN(newRow, column)
                };
            }

            return new List<string>();
        }

        //private IList<string> GetPawnMovesForBlack(int row, int column, Piece chessPiece)
        //{
        //    var newRow = row + 1;

        //    if(row >= 0 && row < 8)
        //    {
        //        return new List<string>()
        //        {
        //            Utilities.GetPositionInPGN(newRow, column)
        //        };
        //    }

        //    return null;
        //}

        //private IList<string> GetPawnMovesForWhite(int row, int column, Piece chessPiece)
        //{
        //    var newRow = row - 1;

        //    if (row >= 0 && row < 8)
        //    {
        //        return new List<string>()
        //        {
        //            Utilities.GetPositionInPGN(newRow, column)
        //        };
        //    }

        //    return null;
        //}
    }
}