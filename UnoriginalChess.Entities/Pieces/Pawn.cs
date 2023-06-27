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
        
        // Check moves for capturing enemy pieces
        positions.AddRange(GetCaptureMoves(board));

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
    
    private IEnumerable<Position> GetCaptureMoves(Board board)
    {
        var positions = new List<Position>();
        int rowDelta = Color == PlayerColor.White ? 1 : -1;

        // Try capturing to the left
        int newRow = Position.Row + rowDelta;
        int newColumn = Position.Column - 1;
        if (newColumn >= 0)
        {
            var piece = board.GetPieceAt(new Position(newRow, newColumn));
            if (piece != null && piece.Color != Color)
            {
                positions.Add(new Position(newRow, newColumn));
            }
        }

        // Try capturing to the right
        newColumn = Position.Column + 1;
        if (newColumn < board.Size)
        {
            var piece = board.GetPieceAt(new Position(newRow, newColumn));
            if (piece != null && piece.Color != Color)
            {
                positions.Add(new Position(newRow, newColumn));
            }
        }

        return positions;
    }

}