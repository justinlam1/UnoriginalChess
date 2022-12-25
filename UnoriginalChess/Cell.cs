using UnoriginalChess.Pieces;

namespace UnoriginalChess;

internal class Cell
{
    public Cell(int row, int column, Piece? piece = null)
    {
        Row = row;
        Column = column;
        Piece = piece;
    }

    // Properties for storing the row and column indices of the cell
    public int Row { get; }
    public int Column { get; }
    
    // Property for storing a piece occupying the cell
    public Piece? Piece { get; set; }
}