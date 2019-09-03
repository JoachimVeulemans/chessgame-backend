using ChessBackend.Services.ChessGame.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;

//TODO refactor whole class

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
            var kingMoves = new List<string>();

            //Top
            if(PositionIsValid(row - 1, column))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row - 1, column));
            }

            //Topright
            if (PositionIsValid(row - 1, column + 1))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row - 1, column + 1));
            }

            //Right
            if (PositionIsValid(row, column + 1))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row, column + 1));
            }

            //Bottomright
            if (PositionIsValid(row + 1, column + 1))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row + 1, column + 1));
            }

            //Bottom
            if (PositionIsValid(row + 1, column))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row + 1, column));
            }

            //Bottomleft
            if (PositionIsValid(row + 1, column - 1))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row + 1, column - 1));
            }

            //Left
            if (PositionIsValid(row, column - 1))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row, column - 1));
            }

            //Topleft
            if (PositionIsValid(row - 1, column - 1))
            {
                kingMoves.Add(Utilities.GetPositionInPGN(row - 1, column - 1));
            }

            return kingMoves;
        }

        private IList<string> GetQueenMoves(int row, int column, Piece chessPiece)
        {
            var queenMoves = new List<string>();

            queenMoves.AddRange(GetBishopMoves(row, column, chessPiece));
            queenMoves.AddRange(GetRookMoves(row, column, chessPiece));

            return queenMoves;
        }

        private IList<string> GetRookMoves(int row, int column, Piece chessPiece)
        {
            var rookMoves = new List<string>();

            //Left
            var newRow = row;
            var newColumn = column-1;

            while(PositionIsValid(newRow, newColumn))
            {
                rookMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));

                newColumn -= 1;
            }

            //Right
            newRow = row;
            newColumn = column + 1;

            while (PositionIsValid(newRow, newColumn))
            {
                rookMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));

                newColumn += 1;
            }

            //Down
            newRow = row + 1;
            newColumn = column;

            while (PositionIsValid(newRow, newColumn))
            {
                rookMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));

                newRow += 1;
            }

            //Up
            newRow = row - 1;
            newColumn = column;

            while (PositionIsValid(newRow, newColumn))
            {
                rookMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));

                newRow -= 1;
            }

            return rookMoves;
        }

        private IList<string> GetBishopMoves(int row, int column, Piece chessPiece)
        {
            var bishopMoves = new List<string>();

            var newRow = row + 1;
            var newColumn = column + 1;

            //Right Down
            while (PositionIsValid(newRow, newColumn))
            {
                bishopMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
                newRow += 1;
                newColumn += 1;
            }

            //Left Up
            newRow = row-1;
            newColumn = column-1;

            while(PositionIsValid(newRow, newColumn))
            {
                bishopMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
                newRow -= 1;
                newColumn -= 1;
            }

            //Left Down
            newRow = row + 1;
            newColumn = column - 1;

            while (PositionIsValid(newRow, newColumn))
            {
                bishopMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
                newRow += 1;
                newColumn -= 1;
            }

            //Right Up
            newRow = row - 1;
            newColumn = column + 1;

            while (PositionIsValid(newRow, newColumn))
            {
                bishopMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
                newRow -= 1;
                newColumn += 1;
            }

            return bishopMoves;
        }

        private IList<string> GetKnightMoves(int row, int column, Piece chessPiece)
        {
            var knightMoves = new List<string>();

            var newRow = row;
            var newColumn = column;

            //1
            newRow += 2;
            newColumn += 1;

            if(PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            //2
            newRow = row;
            newColumn = column;
            newRow += 2;
            newColumn -= 1;

            if (PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            //3
            newRow = row;
            newColumn = column;
            newRow -= 2;
            newColumn += 1;

            if (PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            //4
            newRow = row;
            newColumn = column;
            newRow -= 2;
            newColumn -= 1;

            if (PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            //5
            newRow = row;
            newColumn = column;
            newRow += 1;
            newColumn -= 2;

            if (PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            //6
            newRow = row;
            newColumn = column;
            newRow -= 1;
            newColumn -= 2;

            if (PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            //7
            newRow = row;
            newColumn = column;
            newRow += 1;
            newColumn += 2;

            if (PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            //8
            newRow = row;
            newColumn = column;
            newRow -= 1;
            newColumn += 2;

            if (PositionIsValid(newRow, newColumn))
            {
                knightMoves.Add(Utilities.GetPositionInPGN(newRow, newColumn));
            }

            return knightMoves;
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

            if (PositionIsValid(newRow, column))
            {
                return new List<string>()
                {
                    Utilities.GetPositionInPGN(newRow, column)
                };
            }

            return new List<string>();
        }

        private bool PositionIsValid(int row, int column)
        {
            if(row < 0 || row > 7)
            {
                return false;
            }

            if(column < 0 || column > 7)
            {
                return false;
            }

            return true;
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