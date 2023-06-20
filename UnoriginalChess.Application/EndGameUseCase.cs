using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class EndGameRequest
{
    public Game Game { get; set; }
}

public class EndGameResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
}

public class EndGameUseCase
{
    public EndGameResponse Execute(EndGameRequest request)
    {
        try
        {
            // End the game
            request.Game.EndGame();

            // Return success response
            return new EndGameResponse
            {
                Success = true,
                Message = "Game ended successfully."
            };
        }
        catch (Exception ex)
        {
            // In case of an error, return an error response
            return new EndGameResponse
            {
                Success = false,
                Message = $"Error ending game: {ex.Message}"
            };
        }
    }
}
