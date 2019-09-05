using ChessBackend.Entities.ChessGame;
using Xunit;

namespace ChessBackend.Test.ChessGame
{
    public class PawnTest
    {
        private readonly Pawn _sut;
        public PawnTest()
        {
            _sut = new Pawn(Color.WHITE);
        }

        [Fact]
        public void King_ShouldHaveBlackColorOnCreation()
        {
            //Arrange
            var sut = new Pawn(Color.BLACK);

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
            Assert.Equal(1, _sut.Value);
            Assert.Equal("P", _sut.GetPGN());
        }
    }
}
