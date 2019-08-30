using ChessBackend.Services.ChessGame.Src.Entities;
using ChessBackend.Services.ChessGame.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessBackend.Test.Chessgame
{
    public class RookTest
    {
        private readonly Rook _sut;

        public RookTest()
        {
            _sut = new Rook(Color.WHITE);
        }

        [Fact]
        public void Rook_ShouldHaveBlackColorOnCreation()
        {
            //Arrange
            var sut = new Rook(Color.BLACK);

            //Assert
            Assert.Equal(Color.BLACK, sut.Color);
        }

        [Fact]
        public void Rook_ShouldHaveWhiteColorOnCreation()
        {
            //Assert
            Assert.Equal(Color.WHITE, _sut.Color);
        }

        [Fact]
        public void Rook_ShouldHaveCorrectValueAndPGNOnCreation()
        {
            //Assert
            Assert.Equal(5, _sut.Value);
            Assert.Equal("R", _sut.GetPGN());
        }
    }
}
