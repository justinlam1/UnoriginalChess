namespace UnoriginalChess;

internal abstract class Piece
{
    public PlayerColor Color { get; init; }
    public abstract List<Move> GetLegalMoves(Board board);
}

internal class King : Piece
{
    public bool CanCastle { get; set; } = true;

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}