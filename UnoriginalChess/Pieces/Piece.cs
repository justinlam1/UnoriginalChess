namespace UnoriginalChess.Pieces;

internal abstract class Piece
{
    protected Piece(PlayerColor color, int row, int column)
    {
        Color = color;
        Row = row;
        Column = column;
    }
    
    public PlayerColor Color { get; }
    public int Row { get; }
    public int Column { get; }
    public abstract List<Move> GetLegalMoves(Board board);
}