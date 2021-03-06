﻿using System;
using System.Collections.Generic;
using System.Globalization;
using ChessBackend.Data.DataEntities;

namespace ChessBackend.Entities.ChessGame
{
    public class ChessGame
    {
        public const int BOARDSIZE = 8;
        public string Id { get; set; }
        public Square[,] ChessBoard { get; set; }
        public MoveManager MoveManager { get; set; }
        public string Date { get; set; }
        public User WhitePlayer { get; set; }
        public User BlackPlayer { get; set; }
        public User CurrentPlayer { get; set; }
        public IList<Piece> LostPieces { get; set; }

        public ChessGame(User whitePlayer, User blackPlayer)
        {
            Id = Guid.NewGuid().ToString();
            WhitePlayer = whitePlayer;
            BlackPlayer = blackPlayer;
            Date = DateTime.Now.Date.ToString(CultureInfo.InvariantCulture);
            ResetChessBoard();
            MoveManager = new MoveManager(ChessBoard);
            CurrentPlayer = WhitePlayer;
        }

        public void Move(Move move)
        {

            Square fromSquare = GetSquare(move.From);
            Square toSquare = GetSquare(move.To);
            Piece chessPieceToMove = fromSquare.ChessPiece;
            fromSquare.ChessPiece = null;

            if (toSquare.HasChessPiece)
            {
                LostPieces.Add(toSquare.ChessPiece);
            }

            toSquare.ChessPiece = chessPieceToMove;
            UpdateCurrentPlayer();
        }

        private Square GetSquare(string position)
        {
            foreach(var square in ChessBoard)
            {
                if (square.Position.Equals(position))
                {
                    return square;
                }
            }

            return null;
        }

        private void UpdateCurrentPlayer()
        {
            if(CurrentPlayer == WhitePlayer)
            {
                CurrentPlayer = BlackPlayer;
            }
            else
            {
                CurrentPlayer = WhitePlayer;
            }
        }

        private void ResetChessBoard()
        {
            DeclareChessBoard();
            InitializeChessBoard();
            PutChessPiecesOnTheBoard();
        }

        private void DeclareChessBoard()
        {
            ChessBoard = new Square[BOARDSIZE, BOARDSIZE];
        }

        private void PutChessPiecesOnTheBoard()
        {
            AddWhitePieces();
            AddBlackPieces();
        }

        private void AddBlackPieces()
        {
            ChessBoard[0, 0].ChessPiece = new Rook(Color.BLACK);
            ChessBoard[0, 1].ChessPiece = new Knight(Color.BLACK);
            ChessBoard[0, 2].ChessPiece = new Bishop(Color.BLACK);
            ChessBoard[0, 3].ChessPiece = new Queen(Color.BLACK);
            ChessBoard[0, 4].ChessPiece = new King(Color.BLACK);
            ChessBoard[0, 5].ChessPiece = new Bishop(Color.BLACK);
            ChessBoard[0, 6].ChessPiece = new Knight(Color.BLACK);
            ChessBoard[0, 7].ChessPiece = new Rook(Color.BLACK);

            for (var column = 0; column < BOARDSIZE; column++)
            {
                ChessBoard[1, column].ChessPiece = new Pawn(Color.BLACK);
            }
        }

        private void AddWhitePieces()
        {
            ChessBoard[7, 0].ChessPiece = new Rook(Color.WHITE);
            ChessBoard[7, 1].ChessPiece = new Knight(Color.WHITE);
            ChessBoard[7, 2].ChessPiece = new Bishop(Color.WHITE);
            ChessBoard[7, 3].ChessPiece = new Queen(Color.WHITE);
            ChessBoard[7, 4].ChessPiece = new King(Color.WHITE);
            ChessBoard[7, 5].ChessPiece = new Bishop(Color.WHITE);
            ChessBoard[7, 6].ChessPiece = new Knight(Color.WHITE);
            ChessBoard[7, 7].ChessPiece = new Rook(Color.WHITE);

            for (var column = 0; column < BOARDSIZE; column++)
            {
                ChessBoard[6, column].ChessPiece = new Pawn(Color.WHITE);
            }
        }

        private void InitializeChessBoard()
        {
            for (var row = 0; row < BOARDSIZE; row++)
            {
                for (var column = 0; column < BOARDSIZE; column++)
                {
                    ChessBoard[row, column] = new Square(row, column);
                }
            }
        }

        public bool IsCurrentPlayer(string id)
        {
            return CurrentPlayer.Id.Equals(id);
        }

        public IList<string> GetValidMoves(string position)
        {
            position = Utilities.GetPositionInPGN(Convert.ToInt32(position[0] + ""), Convert.ToInt32(position[2] + ""));
            return MoveManager.GetMoves(GetSquare(position));
        }
    }
}
