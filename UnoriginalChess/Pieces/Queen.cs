namespace UnoriginalChess.Pieces;

internal class Queen : Piece
{
    public Queen(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}