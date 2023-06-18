namespace UnoriginalChess.Entities.Pieces;

public class Pawn : Piece
{
    public Pawn(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        var moves = new List<Move>();

        // Check moves in each direction
        moves.AddRange(GetLegalMovesInDirection(board, Color == PlayerColor.White ? 1 : -1));

        return moves;
    }

    private IEnumerable<Move> GetLegalMovesInDirection(Board board, int rowDelta)
    {
        // TODO: Add ability to perform en passant
        var moves = new List<Move>();

        var nextRow = Position.Row + rowDelta;
        
        while (nextRow >= 0 && nextRow < board.BoardRows && int.Abs(nextRow - Position.Row) <= 2)
        {
            if (board.Cells[nextRow][Position.Column].Piece == null)
            {
                // If cell is empty, add the move to the list
                moves.Add(new Move(Position, new Position(nextRow, Position.Column)));
            }
            else
            {
                // If the cell contains a piece of any color
                break;
            }

            nextRow += rowDelta;
        }

        return moves;
    }
}