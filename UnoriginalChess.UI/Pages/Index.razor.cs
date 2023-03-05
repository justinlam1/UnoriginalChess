using MudBlazor;
using UnoriginalChess.Pieces;

namespace UnoriginalChess.UI.Pages;

public partial class Index
{
    private Game _game;
    private List<DropItem> _items = new();
    protected override Task OnInitializedAsync()
    {
        var board = new Board(8, 8);
        var players = new List<Player>();
        players.Add(new Player("Justin", PlayerColor.White));
        players.Add(new Player("Sarah", PlayerColor.Black));
        
        var display = new ConsoleDisplay();
        _game = new Game(board, players, display);

        for (int i = 0; i < board.BoardRows; i++)
        {
            for (int j = 0; j < board.BoardColumns; j++)
            {
                var piece = board.Cells[i][j].Piece;
                if (piece == null)
                {
                    continue;
                }
                
                _items.Add(new DropItem { Icon = GetIconName(piece), Color = GetColorName(piece), Identifier = $"{i}{j}"});
            }
        }
        
        return base.OnInitializedAsync();
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

    private void ItemUpdated(MudItemDropInfo<DropItem> dropItem)
    {
        var startPosition = dropItem.Item.Identifier.ToPosition();
        var endPosition = dropItem.DropzoneIdentifier.ToPosition();
        var move = new Move(startPosition, endPosition);
        
        _game.MakeMove(move);

        // Remove captured piece from display
        _items.RemoveAll(x => x.Identifier == dropItem.DropzoneIdentifier);
        
        // Update display position of piece to target location
        dropItem.Item.Identifier = dropItem.DropzoneIdentifier;
    }
    
    public class DropItem
    {
        public string Icon { get; init; }
        public Color Color { get; init; }
        public string Identifier { get; set; }
    }
    
    private bool CanMovePiece(DropItem item, string identifier)
    {
        var startPosition = item.Identifier.ToPosition();
        var endPosition = identifier.ToPosition();
        var move = new Move(startPosition, endPosition);
        
        var canMove = _game.CanMove(move);
        
        return canMove;
    }
}