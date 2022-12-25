namespace UnoriginalChess;

internal abstract class Piece
{
    protected Piece(PlayerColor color)
    {
        Color = color;
    }
    
    public PlayerColor Color { get; init; }
    public abstract List<Move> GetLegalMoves(Board board);
}

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

internal class Bishop : Piece
{
    public Bishop(PlayerColor color) : base(color)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}

internal class Knight : Piece
{
    public Knight(PlayerColor color) : base(color)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}

internal class Rook : Piece
{
    public Rook(PlayerColor color) : base(color)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        throw new NotImplementedException();
    }
}

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