using UnoriginalChess.Entities;
using UnoriginalChess.Entities.Exceptions;

namespace UnoriginalChess.Application;

public class MakeMoveRequest
{
    public Game Game { get; set; }
    public Player Player { get; set; }
    public Position Start { get; set; }
    public Position End { get; set; }
}

public class MakeMoveUseCase
{
    private readonly IGameOutputPort _outputPort;

    public MakeMoveUseCase(IGameOutputPort outputPort)
    {
        _outputPort = outputPort;
    }
    
    public void Execute(MakeMoveRequest request)
    {
        try
        {
            request.Game.MovePiece(request.Start, request.End);
            _outputPort.DisplayMessage($"Player {request.Player.Name} moved from {Position.ToChessCoordinates(request.Start)} to {Position.ToChessCoordinates(request.End)}.");
        }
        catch (InvalidMoveException ex)
        {
            _outputPort.DisplayMessage($"Invalid move: {ex.Message}");
        }
        catch (Exception ex)
        {
            _outputPort.DisplayMessage($"Error making move: {ex.Message}");
        }
    }
}
