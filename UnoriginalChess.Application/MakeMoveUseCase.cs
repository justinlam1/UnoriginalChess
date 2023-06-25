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

public class MakeMoveUseCase<T>
{
    private readonly IGameOutputPort<T> _outputPort;

    public MakeMoveUseCase(IGameOutputPort<T> outputPort)
    {
        _outputPort = outputPort;
    }
    
    public T Execute(MakeMoveRequest request)
    {
        try
        {
            request.Game.MovePiece(request.Start, request.End);
            
            return _outputPort.FormatMessage($"Move made from {Position.ToChessCoordinates(request.Start)} to {Position.ToChessCoordinates(request.End)}");
        }
        catch (InvalidMoveException ex)
        {
            return _outputPort.FormatMessage($"Invalid move: {ex.Message}");
        }
        catch (Exception ex)
        {
            return _outputPort.FormatMessage($"Error making move: {ex.Message}");
        }
    }
}
