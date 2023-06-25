using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class StartGameRequest
{
    public List<Player> Players { get; set; }
}

public class StartGameUseCase<T>
{
    private readonly IGameOutputPort<T> _outputPort;

    public StartGameUseCase(IGameOutputPort<T> outputPort)
    {
        _outputPort = outputPort;
    }
    
    public Game? Execute(StartGameRequest request)
    {
        if (request.Players == null || request.Players.Count != 2)
        {
            return null;
        }

        try
        {
            var game = new Game(request.Players);
            
            return game;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}