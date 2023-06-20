using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class StartGameRequest
{
    public List<Player> Players { get; set; }
}

public class StartGameResponse
{
    public bool Success { get; set; }
    public Game Game { get; set; }
    public string Message { get; set; }
}

public class StartGameUseCase
{
    public StartGameResponse Execute(StartGameRequest request)
    {
        if (request.Players == null || request.Players.Count != 2)
        {
            return new StartGameResponse { Success = false, Message = "You need exactly 2 players to start a game." };
        }

        try
        {
            var game = new Game(request.Players);
            return new StartGameResponse { Success = true, Game = game };
        }
        catch (Exception ex)
        {
            return new StartGameResponse { Success = false, Message = ex.Message };
        }
    }
}
