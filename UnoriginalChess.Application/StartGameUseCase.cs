using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class StartGameRequest
{
    public List<Player> Players { get; set; }
}

public class StartGameUseCase
{
    private readonly IGameOutputPort _outputPort;

    public StartGameUseCase(IGameOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
    
    public Game? Execute(StartGameRequest request)
    {
        if (request.Players == null || request.Players.Count != 2)
        {
            _outputPort.DisplayMessage("You need exactly 2 players to start a game.");
            return null;
        }

        try
        {
            var game = new Game(request.Players);
            
            // Display the game start message
            _outputPort.DisplayMessage($"Game started between {request.Players[0].Name} and {request.Players[1].Name}");
            
            // Display the initial board
            _outputPort.DisplayBoard(game.Board);

            return game;
        }
        catch (Exception ex)
        {
            _outputPort.DisplayMessage($"An error occurred while starting the game: {ex.Message}");
            return null;
        }
    }
}
