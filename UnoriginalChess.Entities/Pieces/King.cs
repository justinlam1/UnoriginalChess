namespace UnoriginalChess.Entities.Pieces;

public class King : Piece
{
    public King(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public bool CanCastle { get; set; } = true;

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

        var nextRow = Position.Row + rowDelta;
        var nextColumn = Position.Column + columnDelta;

        if (nextRow >= 0 && nextRow < board.Size && nextColumn >= 0 &&
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
            }
        }

        return positions;
    }
}