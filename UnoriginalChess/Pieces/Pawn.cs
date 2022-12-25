namespace UnoriginalChess.Pieces;

internal class Pawn : Piece
{
    public Pawn(PlayerColor color) : base(color)
    {
    }
    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }

}