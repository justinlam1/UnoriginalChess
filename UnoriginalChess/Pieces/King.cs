namespace UnoriginalChess.Pieces;

internal class King : Piece
{
    public King(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public bool CanCastle { get; set; } = true;

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}