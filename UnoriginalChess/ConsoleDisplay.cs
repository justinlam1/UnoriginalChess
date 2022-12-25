using UnoriginalChess.Pieces;

namespace UnoriginalChess;

internal class ConsoleDisplay : IDisplayBoard
{
    public void DisplayBoard(Board board)
    {
        Console.WriteLine();
        foreach (var row in board.Cells)
        {
            DrawRow(row);
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void DrawRow(List<Cell> row)
    {
        foreach (var cell in row)
        {
            Console.Write(GetSymbol(cell.Piece) + " ");
        }
    }

    private static string GetSymbol(Piece? piece)
    {
        if (piece == null)
        {
            return "-";
        }

        var pieceType = piece.GetType();
        string output;

        if (pieceType == typeof(King))
        {
            output = "k";
        }
        else if (pieceType == typeof(Pawn))
        {
            output = "p";
        }
        else if (pieceType == typeof(Queen))
        {
            output = "q";
        }
        else if (pieceType == typeof(Rook))
        {
            output = "r";
        }
        else if (pieceType == typeof(Knight))
        {
            output = "n";
        }
        else if (pieceType == typeof(Bishop))
        {
            output = "b";
        }
        else
        {
            output = "-";
        }

        if (piece.Color == PlayerColor.White)
        {
            output = output.ToUpper();
        }

        return output;
    }
}