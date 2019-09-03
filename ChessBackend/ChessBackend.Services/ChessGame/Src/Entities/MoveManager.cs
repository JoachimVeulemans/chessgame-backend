using ChessBackend.Services.ChessGame.Src.Enums;
using System.Collections.Generic;

//TODO Constructor with ChessBoard of game so other entities can be checked

namespace ChessBackend.Services.ChessGame.Src.Entities
{
    public class MoveManager
    { 
        public IList<string> GetMoves(Square position)
        {
            IList<string> moveList = new List<string>();

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

            AddMoveToList(row - 1, column, kingMoves);          //Top
            AddMoveToList(row - 1, column + 1, kingMoves);      //Topright
            AddMoveToList(row, column + 1, kingMoves);          //Right
            AddMoveToList(row + 1, column + 1, kingMoves);      //Bottomright
            AddMoveToList(row + 1, column, kingMoves);          //Bottom
            AddMoveToList(row + 1, column - 1, kingMoves);      //Bottomleft
            AddMoveToList(row, column - 1, kingMoves);          //Left
            AddMoveToList(row - 1, column - 1, kingMoves);      //Topleft

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

            rookMoves.AddRange(GetRookUpMoves(row, column));
            rookMoves.AddRange(GetRookDownMoves(row, column));
            rookMoves.AddRange(GetRookLeftMoves(row, column));
            rookMoves.AddRange(GetRookRightMoves(row, column));

            return rookMoves;
        }

        private IEnumerable<string> GetRookRightMoves(int row, int column)
        {
            var moves = new List<string>();
            column++;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                column++;
            }

            return moves;
        }

        private IEnumerable<string> GetRookLeftMoves(int row, int column)
        {
            var moves = new List<string>();
            column--;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                column--;
            }

            return moves;
        }

        private IEnumerable<string> GetRookDownMoves(int row, int column)
        {
            var moves = new List<string>();
            row++;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                row++;
            }

            return moves;
        }

        private IEnumerable<string> GetRookUpMoves(int row, int column)
        {
            var moves = new List<string>();
            row--;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                row--;
            }

            return moves;
        }

        private IList<string> GetBishopMoves(int row, int column, Piece chessPiece)
        {
            var bishopMoves = new List<string>();

            bishopMoves.AddRange(GetBishopRightDownMoves(row, column));
            bishopMoves.AddRange(GetBishopRightUpMoves(row, column));
            bishopMoves.AddRange(GetBishopLeftDownMoves(row, column));
            bishopMoves.AddRange(GetBishopLeftUpMoves(row, column));

            return bishopMoves;
        }

        private IEnumerable<string> GetBishopLeftUpMoves(int row, int column)
        {
            var moves = new List<string>();
            row--;
            column--;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                row--;
                column--;
            }

            return moves;
        }

        private IEnumerable<string> GetBishopLeftDownMoves(int row, int column)
        {
            var moves = new List<string>();
            row++;
            column--;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                row++;
                column--;
            }

            return moves;
        }

        private IEnumerable<string> GetBishopRightUpMoves(int row, int column)
        {
            var moves = new List<string>();
            row--;
            column++;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                row--;
                column++;
            }

            return moves;
        }

        private IEnumerable<string> GetBishopRightDownMoves(int row, int column)
        {
            var moves = new List<string>();
            row++;
            column++;

            while (PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
                row ++;
                column++;
            }

            return moves;
        }

        private IList<string> GetKnightMoves(int row, int column, Piece chessPiece)
        {
            var knightMoves = new List<string>();

            AddMoveToList(row + 2, column + 1, knightMoves);
            AddMoveToList(row + 2, column - 1, knightMoves);
            AddMoveToList(row - 2, column + 1, knightMoves);
            AddMoveToList(row - 2, column - 1, knightMoves);
            AddMoveToList(row + 1, column - 2, knightMoves);
            AddMoveToList(row - 1, column - 2, knightMoves);
            AddMoveToList(row + 1, column + 2, knightMoves);
            AddMoveToList(row - 1, column + 2, knightMoves);

            return knightMoves;
        }

        private IList<string> GetPawnMoves(int row, int column, Piece chessPiece)
        {
            var pawnMoves = new List<string>();

            if(chessPiece.Color == Color.WHITE)
            {
                row--;
            }
            else
            {
                row++;
            }

            AddMoveToList(row, column, pawnMoves);
            return pawnMoves;
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

        private void AddMoveToList(int row, int column, IList<string> moves)
        {
            if(PositionIsValid(row, column))
            {
                moves.Add(Utilities.GetPositionInPGN(row, column));
            }
        }
    }
}