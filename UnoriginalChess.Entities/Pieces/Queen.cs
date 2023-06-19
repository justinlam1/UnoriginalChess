namespace UnoriginalChess.Entities.Pieces;

public class Queen : Piece
{
    public Queen(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Position> GetLegalMoves(Board board)
    {
        var positions = new List<Position>();

        // Check moves in each direction
        positions.AddRange(GetLegalMovesInDirection(board, 1, 0));
        positions.AddRange(GetLegalMovesInDirection(board, 1, -1));
        positions.AddRange(GetLegalMovesInDirection(board, 0, -1));
        positions.AddRange(GetLegalMovesInDirection(board, -1, -1));
        positions.AddRange(GetLegalMovesInDirection(board, -1, 0));
        positions.AddRange(GetLegalMovesInDirection(board, -1, 1));
        positions.AddRange(GetLegalMovesInDirection(board, 0, 1));
        positions.AddRange(GetLegalMovesInDirection(board, 1, 1));

        return positions;
    }

    private IEnumerable<Position> GetLegalMovesInDirection(Board board, int rowDelta, int columnDelta)
    {
        var positions = new List<Position>();
        
        var nextPosition = new Position(Position.Row + rowDelta, Position.Column + columnDelta);

        while (nextPosition.Row >= 0 && nextPosition.Row < board.Size && nextPosition.Column >= 0 &&
               nextPosition.Column < board.Size)
        {
            var pieceAtDestination = board.Cells[nextPosition.Row, nextPosition.Column].Piece;
            
            if (pieceAtDestination == null)
            {
                // If cell is empty, add the move to the list
                positions.Add(nextPosition);
            }
            else if (pieceAtDestination.Color != Color)
            {
                // If the cell contains a piece of the opposite color, add the move to the list then stop
                positions.Add(nextPosition);
                break;
            }
            else
            {
                // If the cell contains a piece of the same color, then stop
                break;
            }

            nextPosition = new Position(nextPosition.Row + rowDelta, nextPosition.Column + columnDelta);
        }

        return positions;
    }
}