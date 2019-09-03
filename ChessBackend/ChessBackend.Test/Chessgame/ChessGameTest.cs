using ChessBackend.Data.Entities;
using ChessBackend.Services.ChessGame.Src;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChessBackend.Test.Chessgame
{
    public class ChessGameTest
    {
        [Fact]
        public void ChessGame_ShouldInitiateCorrectly()
        {
            //Arrange
            var sut = new ChessGame(0, new User(), new User());

            //Assert
            Assert.NotNull(sut);
        } 
    }
}
