using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class EndGameRequest
{
    public Game Game { get; set; }
}

public class EndGameUseCase<T>
{
    private readonly IGameOutputPort<T> _outputPort;

    public EndGameUseCase(IGameOutputPort<T> outputPort)
    {
        _outputPort = outputPort;
    }
    
    public T Execute(EndGameRequest request)
    {
        try
        {
            request.Game.EndGame();
            return _outputPort.FormatMessage("Game ended successfully.");
        }
        catch (Exception ex)
        {
            return _outputPort.FormatMessage($"Error ending game: {ex.Message}");
        }
    }
}
