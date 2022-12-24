namespace UnoriginalChess;

internal record Move()
{
    public Position Start { get; private set; }
    public Position End { get; private set; }

    internal bool IsLegalMove()
    {
        throw new NotImplementedException();
    }
}

internal readonly record struct Position(int X, int Y);