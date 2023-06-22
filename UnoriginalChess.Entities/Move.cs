using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.Entities;

public record Move(Position Start, Position End, Piece MovedPiece, Piece? CapturedPiece)
{
    public Position Start { get; private set; } = Start;
    public Position End { get; private set; } = End;
    public Piece MovedPiece { get; private set; } = MovedPiece;
    public Piece? CapturedPiece { get; private set; } = CapturedPiece;
}