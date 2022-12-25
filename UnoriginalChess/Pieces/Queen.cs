namespace UnoriginalChess.Pieces;

internal class Queen : Piece
{
    public Queen(PlayerColor color) : base(color)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}