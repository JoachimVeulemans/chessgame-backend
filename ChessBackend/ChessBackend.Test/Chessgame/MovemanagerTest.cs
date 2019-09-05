using ChessBackend.Entities.ChessGame;
using Xunit;

namespace ChessBackend.Test.ChessGame
{
    //TODO Chesspiece builder?
    public class MoveManagerTest
    {
        private readonly MoveManager _sut;
        private readonly Square _square;
        public MoveManagerTest()
        {
            _sut = new MoveManager(new Square[0, 0]);
            _square = new Square(3, 4);
        }

        [Fact]
        public void MoveManager_Pawn_GetMovesShouldReturnCorrectMoves()
        {
            //Act
            _square.ChessPiece = new Pawn(Color.BLACK);
            var moves = _sut.GetMoves(_square);

            //Assert
            Assert.Equal(1, moves.Count);
            Assert.Equal("e4", moves[0]);
        }

        [Fact]
        public void MoveManager_Knight_GetMovesShouldReturnCorrectMoves()
        {
            //Act
            _square.ChessPiece = new Knight(Color.BLACK);
            var moves = _sut.GetMoves(_square);

            //Assert
            Assert.Equal(8, moves.Count);
        }

        [Fact]
        public void MoveManager_Bishop_GetMovesShouldReturnCorrectMoves()
        {
            //Act
            _square.ChessPiece = new Bishop(Color.BLACK);
            var moves = _sut.GetMoves(_square);

            //Assert
            Assert.Equal(13, moves.Count);
        }

        [Fact]
        public void MoveManager_Rook_GetMovesShouldReturnCorrectMoves()
        {
            _square.ChessPiece = new Rook(Color.BLACK);
            var moves = _sut.GetMoves(_square);

            //Assert
            Assert.Equal(14, moves.Count);
        }

        [Fact]
        public void MoveManager_Queen_GetMovesShouldReturnCorrectMoves()
        {
            //Act
            _square.ChessPiece = new Queen(Color.BLACK);
            var moves = _sut.GetMoves(_square);

            //Assert
            Assert.Equal(27, moves.Count);
        }

        [Fact]
        public void MoveManager_King_GetMovesShouldReturnCorrectMoves()
        {
            //Act
            _square.ChessPiece = new King(Color.BLACK);
            var moves = _sut.GetMoves(_square);

            //Assert
            Assert.Equal(8, moves.Count);
        }
    }
}