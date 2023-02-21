namespace UnoriginalChess.Pieces;

public class Rook : Piece
{
    public Rook(PlayerColor color, int row, int column) : base(color, row, column)
    {
    }

    public override List<Move> GetLegalMoves(Board board)
    {
        var moves = new List<Move>();
        
        moves.AddRange(GetLegalMovesInDirection(board, 1, 0));
        moves.AddRange(GetLegalMovesInDirection(board, 0, -1));
        moves.AddRange(GetLegalMovesInDirection(board, -1, 0));
        moves.AddRange(GetLegalMovesInDirection(board, 0, 1));

        return moves;
    }

    private IEnumerable<Move> GetLegalMovesInDirection(Board board, int rowDelta, int columnDelta)
    {
        var moves = new List<Move>();

        var nextRow = Row + rowDelta;
        var nextColumn = Column + columnDelta;
        
        while (nextRow >= 0 && nextRow < board.BoardRows && nextColumn >= 0 &&
               nextColumn < board.BoardColumns)
        {
            var pieceAtDestination = board.Cells[nextRow][nextColumn].Piece;
            
            if (pieceAtDestination == null)
            {
                // If cell is empty, add the move to the list
                moves.Add(new Move(new Position(Row, Column), new Position(nextRow, nextColumn)));
            }
            else if (pieceAtDestination.Color != Color)
            {
                // If the cell contains a piece of the opposite color, add the move to the list then stop
                moves.Add(new Move(new Position(Row, Column), new Position(nextRow, nextColumn)));
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

        return moves;
    }
}