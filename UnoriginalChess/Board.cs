namespace UnoriginalChess;

internal class Board
{
    private IList<Cell> Cells { get; set; } = null!;
    public List<Move> Moves { get; private set; }

    internal void SetBoard()
    {
        throw new NotImplementedException();
    }

    internal void UpdateBoard(Move move)
    {
        throw new NotImplementedException();
    }

    internal bool IsCellOccupied(Position position)
    {
        throw new NotImplementedException();
    }
    
    internal Player IsCheck()
    {
        throw new NotImplementedException();
    }

    internal Player IsCheckmate()
    {
        throw new NotImplementedException();
    }
    
    internal bool IsStalemate()
    {
        throw new NotImplementedException();
    }

    internal List<Move> GetLegalMoves(Piece piece)
    {
        throw new NotImplementedException();
    }
}