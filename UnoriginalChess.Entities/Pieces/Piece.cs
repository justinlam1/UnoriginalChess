namespace UnoriginalChess.Entities.Pieces;

public abstract class Piece
{
    protected Piece(PlayerColor color, int row, int column)
    {
        Color = color;
        Position = new Position(row, column);
    }
    
    public PlayerColor Color { get; }
    public Position Position { get; set; }
    public abstract List<Move> GetLegalMoves(Board board);
}