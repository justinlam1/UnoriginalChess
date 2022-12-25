namespace UnoriginalChess.Pieces;

internal class King : Piece
{
    public King(PlayerColor color) : base(color)
    {
    }

    public bool CanCastle { get; set; } = true;

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}