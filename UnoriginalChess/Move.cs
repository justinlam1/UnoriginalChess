namespace UnoriginalChess;

public record Move()
{
    public Move(Position start, Position end) : this()
    {
        Start = start;
        End = end;
    }
    
    public Position Start { get; private set; }
    public Position End { get; private set; }

    internal bool IsLegalMove()
    {
        throw new NotImplementedException();
    }
}

public readonly record struct Position(int Row, int Column);