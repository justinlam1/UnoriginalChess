namespace UnoriginalChess.Pieces;

internal class Pawn : Piece
{
    public Pawn(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }
    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }

}