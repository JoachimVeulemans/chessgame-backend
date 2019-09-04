using ChessBackend.Entities.ChessGame;
using Xunit;

namespace ChessBackend.Test.Chessgame
{
    public class BishopTest
    {
        private readonly Bishop _sut;

        public BishopTest()
        {
            _sut = new Bishop(Color.WHITE);
        }

        [Fact]
        public void King_ShouldHaveBlackColorOnCreation()
        {
            //Arrange
            var sut = new Bishop(Color.BLACK);

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
            Assert.Equal(3, _sut.Value);
            Assert.Equal("B", _sut.GetPGN());
        }
    }
}
