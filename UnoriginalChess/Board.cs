using UnoriginalChess.Exceptions;
using UnoriginalChess.Pieces;

namespace UnoriginalChess;

internal class Board
{
    public List<List<Cell>> Cells { get; private set; }
    public List<Move> Moves { get; private set; }
    public int BoardColumns { get; private set; }
    public int BoardRows { get; private set; }

    public Board(int rows = 8, int columns = 8, bool createEmptyBoard = false)
    {
        // Initialize the board to a BoardRows x BoardColumns array of Cells
        BoardRows = rows;
        BoardColumns = columns;

        // Initialize the list of moves
        Moves = new List<Move>();
        
        Cells = new List<List<Cell>>();
        for (int row = 0; row < BoardRows; row++)
        {
            Cells.Add(new List<Cell>());
            for (int column = 0; column < BoardColumns; column++)
            {
                Cells[row].Add(new Cell(row, column, null));
            }
        }

        if (!createEmptyBoard)
        {
            InitializeStandardBoard();
        }
    }

    private void InitializeStandardBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            Cells[6][i].Piece = new Pawn(PlayerColor.Black, 6, i);
            Cells[1][i].Piece = new Pawn(PlayerColor.White, 1, i);
        }

        Cells[0][0].Piece = new Rook(PlayerColor.White, 0, 0);
        Cells[0][1].Piece = new Knight(PlayerColor.White, 0, 1);
        Cells[0][2].Piece = new Bishop(PlayerColor.White, 0, 2);
        Cells[0][3].Piece = new Queen(PlayerColor.White, 0, 3);
        Cells[0][4].Piece = new King(PlayerColor.White, 0, 4);
        Cells[0][5].Piece = new Bishop(PlayerColor.White, 0, 5);
        Cells[0][6].Piece = new Knight(PlayerColor.White, 0, 6);
        Cells[0][7].Piece = new Rook(PlayerColor.White, 0, 7);

        Cells[7][0].Piece = new Rook(PlayerColor.Black, 7, 0);
        Cells[7][1].Piece = new Knight(PlayerColor.Black, 7, 1);
        Cells[7][2].Piece = new Bishop(PlayerColor.Black, 7, 2);
        Cells[7][3].Piece = new Queen(PlayerColor.Black, 7, 3);
        Cells[7][4].Piece = new King(PlayerColor.Black, 7, 4);
        Cells[7][5].Piece = new Bishop(PlayerColor.Black, 7, 5);
        Cells[7][6].Piece = new Knight(PlayerColor.Black, 7, 6);
        Cells[7][7].Piece = new Rook(PlayerColor.Black, 7, 7);
    }

    internal void UpdateBoard(Move move)
    {
        // Move the piece from the starting cell to the ending cell
        Cell startCell = Cells[move.Start.Row][move.Start.Column];
        Cell endCell = Cells[move.End.Row][move.End.Column];
        endCell.Piece = startCell.Piece;
        startCell.Piece = null;

        endCell.Piece.Row = move.End.Row;
        endCell.Piece.Column = move.End.Column;

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

    internal List<Move> GetLegalMoves(Position position, PlayerColor currentTurn)
    {
        // Get the piece at the specified position
        var piece = Cells[position.Row][position.Column].Piece;

        if (piece is null)
        {
            return new List<Move>();
        }
        
        if (piece.Color != currentTurn)
        {
            throw new InvalidMoveException("The piece at the starting location belongs to another player.");
        }

        return piece.GetLegalMoves(this);
    }
}