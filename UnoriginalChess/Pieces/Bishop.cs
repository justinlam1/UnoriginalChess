namespace UnoriginalChess.Pieces;

internal class Bishop : Piece
{
    public Bishop(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}