namespace ChessBackend.Entities.ChessGame
{
    public abstract class Piece
    {
        public string Position { get; set; }
        public int Value { get; set; }
        public ChessPiece Type { get; set; }
        public Color Color { get; set; }
        public string Name { get; set; }
        public Piece(Color color, ChessPiece type, int value)
        {
            Color = color;
            Type = type;
            Value = value;
            Name = Type.ToString();
        }

        public virtual string GetPGN()
        {
            return Type.ToString()[0] + "";
        }
    }
}
