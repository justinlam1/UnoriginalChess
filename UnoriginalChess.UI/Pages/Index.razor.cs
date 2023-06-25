using Microsoft.AspNetCore.Components;
using MudBlazor;
using UnoriginalChess.Application;
using UnoriginalChess.Entities;

namespace UnoriginalChess.UI.Pages;

public partial class Index
{
    [Inject] public IGameOutputPort<List<DropItem>> Presenter { get; set; } = null!;
    [Inject] public StartGameUseCase<List<DropItem>> StartGame { get; set; }
    [Inject] public MakeMoveUseCase<List<DropItem>> MakeMove { get; set; }
    [Inject] public EndGameUseCase<List<DropItem>> EndGame { get; set; }

    public bool BoardIsFlipped { get; set; }
    
    private Game _game;
    private List<DropItem> _items = new();
    protected override Task OnInitializedAsync()
    {
        var board = new Board(8);
        var players = new List<Player>();
        players.Add(new Player("Justin", PlayerColor.White));
        players.Add(new Player("Sarah", PlayerColor.Black));
        
        
        var startGameRequest = new StartGameRequest(players);
        _game = StartGame.Execute(startGameRequest);
        _items = Presenter.FormatBoard(_game.Board);
        
        return base.OnInitializedAsync();
    }

    

    private void ItemUpdated(MudItemDropInfo<DropItem> dropItem)
    {
        var startPosition = dropItem.Item.Identifier.ToPosition();
        var endPosition = dropItem.DropzoneIdentifier.ToPosition();
        
        // Request to make the move
        var request = new MakeMoveRequest(_game, _game.CurrentTurn, startPosition, endPosition);
        var result = MakeMove.Execute(request);
        
        // Check if the move was unsuccessful
        if (result.StartsWith("Invalid move") || result.StartsWith("Error making move"))
        {
            // TODO: Display the error message to the user

            return;
        }

        // Remove captured piece from display
        _items.RemoveAll(x => x.Identifier == dropItem.DropzoneIdentifier);
        
        // Update display position of piece to target location
        dropItem.Item.Identifier = dropItem.DropzoneIdentifier;
    }

    private bool CanMovePiece(DropItem item, string identifier)
    {
        var startPosition = item.Identifier.ToPosition();
        var endPosition = identifier.ToPosition();

        var piece = _game.Board.GetPieceAt(startPosition);
        
        if (piece == null)
        {
            // The piece doesn't exist, so it can't be moved
            return false;
        }

        if (piece.Color != _game.CurrentTurn.Color)
        {
            return false;
        }

        // Check if the piece can be moved to the new position
        return piece.GetLegalMoves(_game.Board).Contains(endPosition);

    }

    private void FlipBoard()
    {
        BoardIsFlipped = !BoardIsFlipped;
    }
}