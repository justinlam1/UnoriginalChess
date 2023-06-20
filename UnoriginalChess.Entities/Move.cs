using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.Entities;

public record Move()
{
    public Move(Position start, Position end, Piece? capturedPiece) : this()
    {
        Start = start;
        End = end;
        CapturedPiece = capturedPiece;
    }
    
    public Position Start { get; private set; }
    public Position End { get; private set; }
    public Piece? CapturedPiece { get; private set; }
}

public readonly record struct Position(int Row, int Column);