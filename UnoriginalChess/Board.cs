namespace UnoriginalChess;

internal class Board
{
    public Cell[,] Cells { get; private set; }
    public List<Move> Moves { get; private set; }

    public Board(int columns = 8, int rows = 8)
    {
        // Initialize the board to an 8x8 array of Cells
        Cells = new Cell[8, 8];
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Cells[row, column] = new Cell(row, column, null);
            }
        }
        
        // Initialize the list of moves
        Moves = new List<Move>();
    }

    internal void UpdateBoard(Move move)
    {
        // Move the piece from the starting cell to the ending cell
        Cell startCell = Cells[move.Start.Row, move.Start.Column];
        Cell endCell = Cells[move.End.Row, move.End.Column];
        endCell.Piece = startCell.Piece;
        startCell.Piece = null;
        
        // Add the new move to the list of moves
        Moves.Add(move);
    }

    internal bool IsCellOccupied(Position position)
    {
        // Return true if the cell is occupied by a piece, and false otherwise
        return Cells[position.Row, position.Column].Piece != null;
    }
    
    internal Player IsCheck()
    {
        throw new NotImplementedException();
    }

    internal Player IsCheckmate()
    {
        throw new NotImplementedException();
    }
    
    internal bool IsStalemate()
    {
        throw new NotImplementedException();
    }

    internal List<Move> GetLegalMoves(Position position)
    {
        // Get the piece at the specified position
        var piece = Cells[position.Row, position.Column].Piece;

        if (piece is null)
        {
            return new List<Move>();
        }

        return piece.GetLegalMoves(this);
    }
}