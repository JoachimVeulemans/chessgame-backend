using System;
using System.Collections.Generic;

namespace ChessBackend.Entities.ChessGame
{
    public class MoveManager
    {
        private Square[,] _chessBoard;
        private int _chessPieceRow;
        private int _chessPieceColumn;
        private int _currentRow;
        private int _currentColumn;
        private Piece _chessPiece;

        public MoveManager(Square[,] chessBoard)
        {
            _chessBoard = chessBoard;
        }
        public IList<string> GetMoves(Square position)
        {
            IList<string> moveList = new List<string>();
            _chessPieceRow = position.Row;
            _chessPieceColumn = position.Column;
            _chessPiece = position.ChessPiece;

            switch (position.ChessPiece.Type)
            {
                case ChessPiece.PAWN:
                    moveList = GetPawnMoves();
                    break;
                case ChessPiece.KNIGHT:
                    moveList = GetKnightMoves();
                    break;
                case ChessPiece.BISHOP:
                    moveList = GetBishopMoves();
                    break;
                case ChessPiece.ROOK:
                    moveList = GetRookMoves();
                    break;
                case ChessPiece.QUEEN:
                    moveList = GetQueenMoves();
                    break;
                case ChessPiece.KING:
                    moveList = GetKingMoves();
                    break;
            }

            return moveList;
        }

        private IList<string> GetKingMoves()
        {
            var kingMoves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;

            //TODO Refactor
            AddMoveToList(_currentRow - 1, _currentColumn, kingMoves);          //Top
            AddMoveToList(_currentRow - 1, _currentColumn + 1, kingMoves);      //Topright
            AddMoveToList(_currentRow, _currentColumn + 1, kingMoves);          //Right
            AddMoveToList(_currentRow + 1, _currentColumn + 1, kingMoves);      //Bottomright
            AddMoveToList(_currentRow + 1, _currentColumn, kingMoves);          //Bottom
            AddMoveToList(_currentRow + 1, _currentColumn - 1, kingMoves);      //Bottomleft
            AddMoveToList(_currentRow, _currentColumn - 1, kingMoves);          //Left
            AddMoveToList(_currentRow - 1, _currentColumn - 1, kingMoves);      //Topleft

            return kingMoves;
        }

        private IList<string> GetQueenMoves()
        {
            var queenMoves = new List<string>();

            queenMoves.AddRange(GetBishopMoves());
            queenMoves.AddRange(GetRookMoves());

            return queenMoves;
        }

        private IList<string> GetRookMoves()
        {
            var rookMoves = new List<string>();

            rookMoves.AddRange(GetRookUpMoves());
            rookMoves.AddRange(GetRookDownMoves());
            rookMoves.AddRange(GetRookLeftMoves());
            rookMoves.AddRange(GetRookRightMoves());

            return rookMoves;
        }

        private IEnumerable<string> GetRookRightMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;

            _currentColumn++;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentColumn++;
            }

            return moves;
        }

        private IEnumerable<string> GetRookLeftMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;
            _currentColumn--;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentColumn--;
            }

            return moves;
        }

        private bool PositionHasChessPiece()
        {
            return GetCurrentSquare().HasChessPiece;
        }

        private Square GetCurrentSquare()
        {
            return _chessBoard[_currentRow, _currentColumn];
        }

        private IEnumerable<string> GetRookDownMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;

            _currentRow++;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentRow++;
            }

            return moves;
        }

        private IEnumerable<string> GetRookUpMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;
            _currentRow--;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentRow--;
            }

            return moves;
        }

        private IList<string> GetBishopMoves()
        {
            var bishopMoves = new List<string>();

            bishopMoves.AddRange(GetBishopRightDownMoves());
            bishopMoves.AddRange(GetBishopRightUpMoves());
            bishopMoves.AddRange(GetBishopLeftDownMoves());
            bishopMoves.AddRange(GetBishopLeftUpMoves());

            return bishopMoves;
        }

        private IEnumerable<string> GetBishopLeftUpMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;

            _currentRow--;
            _currentColumn--;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentRow--;
                _currentColumn--;
            }

            return moves;
        }

        private IEnumerable<string> GetBishopLeftDownMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;
            _currentRow++;
            _currentColumn--;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentRow++;
                _currentColumn--;
            }

            return moves;
        }

        private IEnumerable<string> GetBishopRightUpMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;
            _currentRow--;
            _currentColumn++;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentRow--;
                _currentColumn++;
            }

            return moves;
        }

        private IEnumerable<string> GetBishopRightDownMoves()
        {
            var moves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;

            _currentRow++;
            _currentColumn++;

            while (PositionIsValid())
            {
                moves.Add(Utilities.GetPositionInPGN(_currentRow, _currentColumn));
                _currentRow ++;
                _currentColumn++;
            }

            return moves;
        }

        private IList<string> GetKnightMoves()
        {
            var knightMoves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;

            //TODO Refactor
            AddMoveToList(_currentRow + 2, _currentColumn + 1, knightMoves);
            AddMoveToList(_currentRow + 2, _currentColumn - 1, knightMoves);
            AddMoveToList(_currentRow - 2, _currentColumn + 1, knightMoves);
            AddMoveToList(_currentRow - 2, _currentColumn - 1, knightMoves);
            AddMoveToList(_currentRow + 1, _currentColumn - 2, knightMoves);
            AddMoveToList(_currentRow - 1, _currentColumn - 2, knightMoves);
            AddMoveToList(_currentRow + 1, _currentColumn + 2, knightMoves);
            AddMoveToList(_currentRow - 1, _currentColumn + 2, knightMoves);

            return knightMoves;
        }

        private IList<string> GetPawnMoves()
        {
            var pawnMoves = new List<string>();
            _currentRow = _chessPieceRow;
            _currentColumn = _chessPieceColumn;

            if (_chessPiece.Color == Color.WHITE)
            {
                _currentRow--;
            }
            else
            {
                _currentRow++;
            }

            AddMoveToList(_currentRow, _currentColumn, pawnMoves);
            return pawnMoves;
        }

        private bool PositionIsValid()
        {
            return !PositionIsOutOfBounds() && PositionIsLegitimate();
        }

        private bool PositionIsLegitimate()
        {
            if (PositionHasChessPiece())
            {
                if (GetCurrentSquare().ChessPiece.Color == _chessPiece.Color)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return true;
        }

        private bool PositionIsOutOfBounds()
        {
            if (_currentRow < 0 || _currentRow > 7)
            {
                return true;
            }

            if (_currentColumn < 0 || _currentColumn > 7)
            {
                return true;
            }

            return false;
        }

        private bool PositionIsValid(int row, int column)
        {
            if (row < 0 || row > 7)
            {
                return false;
            }

            if (column < 0 || column > 7)
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