﻿using ChessBackend.Entities.ChessGame;
using Xunit;

namespace ChessBackend.Test.ChessGame
{
    public class QueenTest
    {
        private readonly Queen _sut;
        public QueenTest()
        {
            _sut = new Queen(Color.WHITE);
        }

        [Fact]
        public void Queen_ShouldHaveBlackColorOnCreation()
        {
            //Arrange
            var sut = new Queen(Color.BLACK);

            //Assert
            Assert.Equal(Color.BLACK, sut.Color);
        }

        [Fact]
        public void Queen_ShouldHaveWhiteColorOnCreation()
        {
            //Assert
            Assert.Equal(Color.WHITE, _sut.Color);
        }

        [Fact]
        public void Queen_ShouldHaveCorrectValueAndPGNOnCreation()
        {
            //Assert
            Assert.Equal(9, _sut.Value);
            Assert.Equal("Q", _sut.GetPGN());
        }

    }
}
