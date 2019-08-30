using ChessBackend.Services.ChessGame.Src.Entities;
using ChessBackend.Services.ChessGame.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessBackend.Test.Chessgame
{
    public class KnightTest
    {
        private readonly Knight _sut;
        public KnightTest()
        {
            _sut = new Knight(Color.WHITE);
        }

        [Fact]
        public void Knight_ShouldHaveBlackColorOnCreation()
        {
            //Arrange
            var sut = new Knight(Color.BLACK);

            //Assert
            Assert.Equal(Color.BLACK, sut.Color);
        }

        [Fact]
        public void Knight_ShouldHaveWhiteColorOnCreation()
        {
            //Assert
            Assert.Equal(Color.WHITE, _sut.Color);
        }

        [Fact]
        public void Knight_ShouldHaveCorrectValueAndPGNOnCreation()
        {
            //Assert
            Assert.Equal(3, _sut.Value);
            Assert.Equal("N", _sut.GetPGN());
        }
    }
}
