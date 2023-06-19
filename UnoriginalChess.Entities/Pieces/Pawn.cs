namespace UnoriginalChess.Entities.Pieces;

public class Pawn : Piece
{
    public Pawn(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Position> GetLegalMoves(Board board)
    {
        var positions = new List<Position>();

        // Check moves in each direction
        positions.AddRange(GetLegalMovesInDirection(board, Color == PlayerColor.White ? 1 : -1));

        return positions;
    }

    private IEnumerable<Position> GetLegalMovesInDirection(Board board, int rowDelta)
    {
        // TODO: Add ability to perform en passant
        var positions = new List<Position>();

        var nextRow = Position.Row + rowDelta;
        
        while (nextRow >= 0 && nextRow < board.Size && int.Abs(nextRow - Position.Row) <= 2)
        {
            if (board.Cells[nextRow, Position.Column].Piece == null)
            {
                // If cell is empty, add the move to the list
                positions.Add(new Position(nextRow, Position.Column));
            }
            else
            {
                // If the cell contains a piece of any color
                break;
            }

            nextRow += rowDelta;
        }

        return positions;
    }
}