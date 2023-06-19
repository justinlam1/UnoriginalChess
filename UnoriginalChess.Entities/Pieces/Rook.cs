namespace UnoriginalChess.Entities.Pieces;

public class Rook : Piece
{
    public Rook(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Position> GetLegalMoves(Board board)
    {
        var positions = new List<Position>();
        
        positions.AddRange(GetLegalMovesInDirection(board, 1, 0));
        positions.AddRange(GetLegalMovesInDirection(board, 0, -1));
        positions.AddRange(GetLegalMovesInDirection(board, -1, 0));
        positions.AddRange(GetLegalMovesInDirection(board, 0, 1));

        return positions;
    }

    private IEnumerable<Position> GetLegalMovesInDirection(Board board, int rowDelta, int columnDelta)
    {
        var positions = new List<Position>();

        var nextRow = Position.Row + rowDelta;
        var nextColumn = Position.Column + columnDelta;
        
        while (nextRow >= 0 && nextRow < board.Size && nextColumn >= 0 &&
               nextColumn < board.Size)
        {
            var pieceAtDestination = board.Cells[nextRow, nextColumn].Piece;
            
            if (pieceAtDestination == null)
            {
                // If cell is empty, add the move to the list
                positions.Add(new Position(nextRow, nextColumn));
            }
            else if (pieceAtDestination.Color != Color)
            {
                // If the cell contains a piece of the opposite color, add the move to the list then stop
                positions.Add(new Position(nextRow, nextColumn));
                break;
            }
            else
            {
                // If the cell contains a piece of the same color, then stop
                break;
            }
            
            nextRow += rowDelta;
            nextColumn += columnDelta;
        }

        return positions;
    }
}