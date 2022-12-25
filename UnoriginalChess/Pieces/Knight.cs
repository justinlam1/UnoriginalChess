namespace UnoriginalChess.Pieces;

internal class Knight : Piece
{
    public Knight(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}