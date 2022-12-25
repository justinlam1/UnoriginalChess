namespace UnoriginalChess.Pieces;

internal abstract class Piece
{
    protected Piece(PlayerColor color)
    {
        Color = color;
    }
    
    public PlayerColor Color { get; init; }
    public abstract List<Move> GetLegalMoves(Board board);
}