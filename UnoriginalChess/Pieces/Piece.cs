namespace UnoriginalChess.Pieces;

public abstract class Piece
{
    protected Piece(PlayerColor color, int row, int column)
    {
        Color = color;
        Row = row;
        Column = column;
    }
    
    public PlayerColor Color { get; }
    public int Row { get; set; }
    public int Column { get; set; }
    public abstract List<Move> GetLegalMoves(Board board);
}