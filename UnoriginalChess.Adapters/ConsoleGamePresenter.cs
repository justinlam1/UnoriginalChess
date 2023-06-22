using UnoriginalChess.Entities;
using UnoriginalChess.Entities.Pieces;

namespace UnoriginalChess.Adapters;

public class ConsoleGamePresenter : IGameOutputPort
{
    public void DisplayStartGame(Player player1, Player player2)
    {
        Console.WriteLine("Game started between {0} and {1}", player1.Name, player2.Name);
    }

    public void DisplayMove(Move move)
    {
        Console.WriteLine("{0} player moved {1} from {2},{3} to {4},{5}", 
            move.MovedPiece.Color, move.MovedPiece.GetType().Name, move.Start.Row, move.Start.Column, move.End.Row, move.End.Column);
    }

    public void DisplayInvalidMove(Move move, string reason)
    {
        Console.WriteLine("Invalid move from {0},{1} to {2},{3} due to: {4}", 
            move.Start.Row, move.Start.Column, move.End.Row, move.End.Column, reason);
    }

    public void DisplayEndGame(Player winningPlayer)
    {
        Console.WriteLine("Game ended. Winner: {0}", winningPlayer.Name);
    }

    public void DisplayDrawGame()
    {
        Console.WriteLine("Game ended. It's a draw.");
    }

    public void DisplayUndoMove(Move move)
    {
        Console.WriteLine("Undo move from {0},{1} to {2},{3}.", 
            move.Start.Row, move.Start.Column, move.End.Row, move.End.Column);
    }

    public void DisplayBoard(Board board)
    {
        for (int row = 0; row < board.Size; row++)
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