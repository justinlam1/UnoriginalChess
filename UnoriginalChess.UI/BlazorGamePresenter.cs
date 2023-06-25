using MudBlazor;
using UnoriginalChess.Application;
using UnoriginalChess.Entities;
using UnoriginalChess.Entities.Pieces;
using Position = UnoriginalChess.Entities.Position;

namespace UnoriginalChess.UI;

public class BlazorGamePresenter : IGameOutputPort<List<DropItem>>
{
    public List<DropItem> FormatBoard(Board board, bool isWhitePerspective)
    {
        var formattedBoard = new List<DropItem>();
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                var piece = board.GetPieceAt(new Position(row, col));
                if (piece != null)
                {
                    formattedBoard.Add(new DropItem
                    {
                        Icon = GetIconName(piece),
                        Color = GetColorName(piece),
                        Identifier = $"{row}{col}"
                    });
                }
            }
        }

        // Flip the board for black perspective if needed
        if (!isWhitePerspective)
        {
            formattedBoard.Reverse();
        }
        
        return formattedBoard;
    }

    public string FormatMessage(string message)
    {
        return message;
    }
    
    private Color GetColorName(Piece piece)
    {
        if (piece.Color == PlayerColor.White)
        {
            return Color.Primary;
        }
        else
        {
            return Color.Secondary;
        }
    }

    private string GetIconName(Piece piece)
    {
        return piece.GetType().Name switch
        {
            nameof(Rook) => Icons.Custom.Uncategorized.ChessRook,
            nameof(Knight) => Icons.Custom.Uncategorized.ChessKnight,
            nameof(Bishop) => Icons.Custom.Uncategorized.ChessBishop,
            nameof(King) => Icons.Custom.Uncategorized.ChessKing,
            nameof(Queen) => Icons.Custom.Uncategorized.ChessQueen,
            nameof(Pawn) => Icons.Custom.Uncategorized.ChessPawn,
            _ => ""
        };
    }
}