using System;
using ChessBackend.Entities.ChessGame;
using Xunit;

namespace ChessBackend.Test.Chessgame
{
    public class SquareTest
    {
        private Square _sut;
        public SquareTest()
        {
            _sut = new Square(new Random().Next(8), new Random().Next(8));
        }

        [Theory]
        [InlineData(0,0, "a8")]
        [InlineData(1, 1, "b7")]
        [InlineData(2, 2, "c6")]
        [InlineData(3, 3, "d5")]
        [InlineData(4, 4, "e4")]
        [InlineData(5, 5, "f3")]
        [InlineData(6, 6, "g2")]
        [InlineData(7, 7, "h1")]
        public void Square_ShouldHaveCorrectPosition(int row, int column, string expected)
        {
            //Arrange
            var _sut = new Square(row, column);

            //Assert
            Assert.Equal(expected, _sut.Position);
        }

        [Fact]
        public void Square_ShouldNotHaveAChessPiece()
        {
            //Act
            _sut.ChessPiece = null;

            //Assert
            Assert.False(_sut.HasChessPiece);
        }

        [Fact]
        public void Square_ShouldHaveAChessPiece()
        {
            //Act
            _sut.ChessPiece = new Pawn(Color.WHITE);

            //Assert
            Assert.True(_sut.HasChessPiece);
        }

    }
}
