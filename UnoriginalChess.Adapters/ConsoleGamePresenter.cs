using UnoriginalChess.Application;
using UnoriginalChess.Entities;
using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.Adapters;

public class ConsoleGamePresenter : IGameOutputPort
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayBoard(Board board, bool isFlipped)
    {
        if (isFlipped)
        {
            for (int row = 0; row < board.Size; row++)
            {
                DisplayRow(board, row);
            }
        }
        else
        {
            for (int row = board.Size - 1; row >= 0; row--)
            {
                DisplayRow(board, row);
            }
        }
    }

    private void DisplayRow(Board board, int row)
    {
        for (int col = 0; col < board.Size; col++)
        {
            var piece = board.GetPieceAt(new Position(row, col));
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                Console.Write($"{GetSymbol(piece)} ");
            }
        }
        Console.WriteLine();
    }
    
    private string GetSymbol(Piece? piece)
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