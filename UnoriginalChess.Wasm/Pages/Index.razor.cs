using Microsoft.AspNetCore.Components;
using MudBlazor;
using UnoriginalChess.Application;
using UnoriginalChess.Entities;

namespace UnoriginalChess.Wasm.Pages;

public partial class Index
{
    [Inject] public IGameOutputPort<List<DropItem>> Presenter { get; set; } = null!;
    [Inject] public StartGameUseCase<List<DropItem>> StartGame { get; set; }
    [Inject] public MakeMoveUseCase<List<DropItem>> MakeMove { get; set; }
    [Inject] public EndGameUseCase<List<DropItem>> EndGame { get; set; }

    private bool BoardIsFlipped { get; set; }
    private Game Game { get; set; }
    private List<DropItem> Items { get; set; } = new();
    public string GameMessage { get; set; }
    
    protected override Task OnInitializedAsync()
    {
        var board = new UnoriginalChess.Entities.Board(8);
        var players = new List<Player>();
        players.Add(new Player("Player 1", PlayerColor.White));
        players.Add(new Player("Player 2", PlayerColor.Black));
        
        
        var startGameRequest = new StartGameRequest(players);
        Game = StartGame.Execute(startGameRequest);
        Items = Presenter.FormatBoard(Game.Board);
        
        return base.OnInitializedAsync();
    }
    
    private void ItemUpdated(MudItemDropInfo<DropItem> dropItem)
    {
        var startPosition = dropItem.Item.Identifier.ToPosition();
        var endPosition = dropItem.DropzoneIdentifier.ToPosition();
        
        // Request to make the move
        var request = new MakeMoveRequest(Game, Game.CurrentTurn, startPosition, endPosition);
        var result = MakeMove.Execute(request);

        GameMessage = result;
        
        // Check if the move was unsuccessful
        if (result.StartsWith("Invalid move") || result.StartsWith("Error making move"))
        {
            // TODO: Display the error message to the user

            return;
        }

        // Remove captured piece from display
        Items.RemoveAll(x => x.Identifier == dropItem.DropzoneIdentifier);
        
        // Update display position of piece to target location
        dropItem.Item.Identifier = dropItem.DropzoneIdentifier;
    }

    private bool CanMovePiece(DropItem item, string identifier)
    {
        var startPosition = item.Identifier.ToPosition();
        var endPosition = identifier.ToPosition();

        var piece = Game.Board.GetPieceAt(startPosition);
        
        if (piece == null)
        {
            // The piece doesn't exist, so it can't be moved
            return false;
        }

        if (piece.Color != Game.CurrentTurn.Color)
        {
            return false;
        }

        // Check if the piece can be moved to the new position
        return piece.GetLegalMoves(Game.Board).Contains(endPosition);

    }

    private void FlipBoard()
    {
        BoardIsFlipped = !BoardIsFlipped;
    }
}