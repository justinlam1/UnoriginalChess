using System.Text;
using UnoriginalChess.Application;
using UnoriginalChess.Entities;
using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.Adapters;

public class ConsoleGamePresenter : IGameOutputPort<string>
{
    public string FormatBoard(Board board, bool isFlipped = false)
    {
        var builder = new StringBuilder();

        if (isFlipped)
        {
            for (int row = 0; row < board.Size; row++)
            {
                builder.AppendLine(FormatRow(board, row));
            }
        }
        else
        {
            for (int row = board.Size - 1; row >= 0; row--)
            {
                builder.AppendLine(FormatRow(board, row));
            }
        }

        return builder.ToString();
    }

    private string FormatRow(Board board, int row)
    {
        var builder = new StringBuilder();

        for (int col = 0; col < board.Size; col++)
        {
            var piece = board.GetPieceAt(new Position(row, col));
            if (piece == null)
            {
                builder.Append("- ");
            }
            else
            {
                builder.Append($"{GetSymbol(piece)} ");
            }
        }

        return builder.ToString();
    }

    public string FormatMessage(string message)
    {
        return message;
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