namespace UnoriginalChess.Pieces;

public class King : Piece
{
    public King(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public bool CanCastle { get; set; } = true;

    public override List<Move> GetLegalMoves(Board board)
    {
        var moves = new List<Move>();

        // Check moves in each direction
        moves.AddRange(GetLegalMovesInDirection(board, 1, 0));
        moves.AddRange(GetLegalMovesInDirection(board, 1, -1));
        moves.AddRange(GetLegalMovesInDirection(board, 0, -1));
        moves.AddRange(GetLegalMovesInDirection(board, -1, -1));
        moves.AddRange(GetLegalMovesInDirection(board, -1, 0));
        moves.AddRange(GetLegalMovesInDirection(board, -1, 1));
        moves.AddRange(GetLegalMovesInDirection(board, 0, 1));
        moves.AddRange(GetLegalMovesInDirection(board, 1, 1));

        return moves;
    }

    private IEnumerable<Move> GetLegalMovesInDirection(Board board, int rowDelta, int columnDelta)
    {
        var moves = new List<Move>();

        var nextRow = Position.Row + rowDelta;
        var nextColumn = Position.Column + columnDelta;

        if (nextRow >= 0 && nextRow < board.BoardRows && nextColumn >= 0 &&
               nextColumn < board.BoardColumns)
        {
            var pieceAtDestination = board.Cells[nextRow][nextColumn].Piece;
            
            if (pieceAtDestination == null)
            {
                // If cell is empty, add the move to the list
                moves.Add(new Move(Position, new Position(nextRow, nextColumn)));
            }
            else if (pieceAtDestination.Color != Color)
            {
                // If the cell contains a piece of the opposite color, add the move to the list then stop
                moves.Add(new Move(Position, new Position(nextRow, nextColumn)));
            }
        }

        return moves;
    }
}