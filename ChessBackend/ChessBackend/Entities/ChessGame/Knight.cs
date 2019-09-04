namespace ChessBackend.Entities.ChessGame
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(color, ChessPiece.KNIGHT, 3) { }

        public override string GetPGN()
        {
            return Type.ToString()[1] + "";
        }
    }
}
