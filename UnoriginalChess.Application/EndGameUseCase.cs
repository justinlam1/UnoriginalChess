using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class EndGameRequest
{
    public Game Game { get; set; }
}

public class EndGameUseCase
{
    private readonly IGameOutputPort _outputPort;

    public EndGameUseCase(IGameOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
    
    public void Execute(EndGameRequest request)
    {
        try
        {
            request.Game.EndGame();
            _outputPort.DisplayMessage("Game ended successfully.");
        }
        catch (Exception ex)
        {
            _outputPort.DisplayMessage($"Error ending game: {ex.Message}");
        }
    }
}
