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
        public void MoveManager_GetMovesShouldReturnCorrectMoves()
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
    }
}
