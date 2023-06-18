using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.Entities;

public class ConsoleDisplay : IDisplayBoard
{
    public void DisplayBoard(Board board)
    {
        Console.WriteLine();

        for (int i = board.Size - 1; i >= 0; i--)
        {
            for (int j = 0; j < board.Size; j++)
            {
                Console.Write(GetSymbol(board.Cells[i, j].Piece) + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
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