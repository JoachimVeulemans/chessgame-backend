using ChessBackend.Services.ChessGame.Src.Entities;
using ChessBackend.Services.ChessGame.Src.Enums;
using Xunit;

namespace ChessBackend.Test.Chessgame
{
    public class KingTest
    {
        private readonly King _sut;
        public KingTest()
        {
            _sut = new King(Color.WHITE);
        }

        [Fact]
        public void King_ShouldHaveBlackColorOnCreation()
        {
            //Arrange
            var sut = new King(Color.BLACK);

            //Assert
            Assert.Equal(Color.BLACK, sut.Color);
        }

        [Fact]
        public void King_ShouldHaveWhiteColorOnCreation()
        {
            //Assert
            Assert.Equal(Color.WHITE, _sut.Color);
        }

        [Fact]
        public void King_ShouldHaveCorrectValueAndPGNOnCreation()
        {
            //Assert
            Assert.Equal(99, _sut.Value);
            Assert.Equal("K", _sut.GetPGN());
        }
    }

}