namespace ChessBackend.Entities.ChessGame
{
    public class Pawn : Piece
    {
        public Pawn(Color color) : base(color, ChessPiece.PAWN, 1) { }
    }
}
