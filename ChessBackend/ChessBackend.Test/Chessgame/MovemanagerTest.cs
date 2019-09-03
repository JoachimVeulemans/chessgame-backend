using ChessBackend.Services.ChessGame.Src.Entities;
using ChessBackend.Services.ChessGame.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessBackend.Test.Chessgame
{
    public class MovemanagerTest
    {
        [Fact]
        public void MoveManager_Pawn_GetMovesShouldReturnCorrectMoves()
        {
            //Arrange
            var _sut = new MoveManager();
            var square = new Square(3, 4)
            {
                ChessPiece = new Pawn(Color.BLACK)
            };

            //Act
            var moves = _sut.GetMoves(square);

            //Assert
            Assert.Equal(1, moves.Count);
            Assert.Equal("e4", moves[0]);
        }

        [Fact]
        public void MoveManager_Knight_GetMovesShouldReturnCorrectMoves()
        {
            //Arrange
            var _sut = new MoveManager();
            var square = new Square(3, 4)
            {
                ChessPiece = new Knight(Color.BLACK)
            };

            //Act
            var moves = _sut.GetMoves(square);

            //Assert
            Console.WriteLine(moves);
            Assert.Equal(8, moves.Count);
        }

        [Fact]
        public void MoveManager_Bishop_GetMovesShouldReturnCorrectMoves()
        {
            //Arrange
            var _sut = new MoveManager();
            var square = new Square(3, 4)
            {
                ChessPiece = new Bishop(Color.BLACK)
            };

            //Act
            var moves = _sut.GetMoves(square);

            //Assert
            Assert.Equal(13, moves.Count);
        }

        [Fact]
        public void MoveManager_Rook_GetMovesShouldReturnCorrectMoves()
        {
            //Arrange
            var _sut = new MoveManager();
            var square = new Square(3, 4)
            {
                ChessPiece = new Rook(Color.BLACK)
            };

            //Act
            var moves = _sut.GetMoves(square);

            //Assert
            Assert.Equal(14, moves.Count);
        }

        [Fact]
        public void MoveManager_Queen_GetMovesShouldReturnCorrectMoves()
        {
            //Arrange
            var _sut = new MoveManager();
            var square = new Square(3, 4)
            {
                ChessPiece = new Queen(Color.BLACK)
            };

            //Act
            var moves = _sut.GetMoves(square);

            //Assert
            Assert.Equal(27, moves.Count);
        }

        [Fact]
        public void MoveManager_King_GetMovesShouldReturnCorrectMoves()
        {
            //Arrange
            var _sut = new MoveManager();
            var square = new Square(3, 4)
            {
                ChessPiece = new King(Color.BLACK)
            };

            //Act
            var moves = _sut.GetMoves(square);

            //Assert
            Assert.Equal(8, moves.Count);
        }
    }
}