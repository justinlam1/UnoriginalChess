namespace UnoriginalChess.Pieces;

internal class Rook : Piece
{
    public Rook(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}