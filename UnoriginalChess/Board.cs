namespace UnoriginalChess;

internal class Board
{
    public List<List<Cell>> Cells { get; private set; }
    public List<Move> Moves { get; private set; }

    public Board(int columns = 8, int rows = 8)
    {
        // Initialize the board to an 8x8 array of Cells
        Cells = new List<List<Cell>>();
        for (int row = 0; row < rows; row++)
        {
            Cells.Add(new List<Cell>());
            for (int column = 0; column < columns; column++)
            {
                Cells[row].Add(new Cell(row, column, null));
            }
        }

        for (int i = 0; i < 8; i++)
        {
            Cells[1][i].Piece = new Pawn(PlayerColor.Black);
            Cells[6][i].Piece = new Pawn(PlayerColor.White);
        }

        Cells[7][0].Piece = new Rook(PlayerColor.White);
        Cells[7][1].Piece = new Knight(PlayerColor.White);
        Cells[7][2].Piece = new Bishop(PlayerColor.White);
        Cells[7][3].Piece = new Queen(PlayerColor.White);
        Cells[7][4].Piece = new King(PlayerColor.White);
        Cells[7][5].Piece = new Bishop(PlayerColor.White);
        Cells[7][6].Piece = new Knight(PlayerColor.White);
        Cells[7][7].Piece = new Rook(PlayerColor.White);

        Cells[0][0].Piece = new Rook(PlayerColor.Black);
        Cells[0][1].Piece = new Knight(PlayerColor.Black);
        Cells[0][2].Piece = new Bishop(PlayerColor.Black);
        Cells[0][3].Piece = new Queen(PlayerColor.Black);
        Cells[0][4].Piece = new King(PlayerColor.Black);
        Cells[0][5].Piece = new Bishop(PlayerColor.Black);
        Cells[0][6].Piece = new Knight(PlayerColor.Black);
        Cells[0][7].Piece = new Rook(PlayerColor.Black);

        // Initialize the list of moves
        Moves = new List<Move>();
    }

    internal void UpdateBoard(Move move)
    {
        // Move the piece from the starting cell to the ending cell
        Cell startCell = Cells[move.Start.Row][move.Start.Column];
        Cell endCell = Cells[move.End.Row][move.End.Column];
        endCell.Piece = startCell.Piece;
        startCell.Piece = null;

        // Add the new move to the list of moves
        Moves.Add(move);
    }

    internal bool IsCellOccupied(Position position)
    {
        // Return true if the cell is occupied by a piece, and false otherwise
        return Cells[position.Row][position.Column].Piece != null;
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
        var piece = Cells[position.Row][position.Column].Piece;

        if (piece is null)
        {
            return new List<Move>();
        }

        return piece.GetLegalMoves(this);
    }
}