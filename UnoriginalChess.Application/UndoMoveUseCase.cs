using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class UndoMoveRequest
{
    public Game Game { get; set; }
    public Player Player { get; set; }
}

public class UndoMoveResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public Game Game { get; set; }
}

public class UndoMoveUseCase
{
    public UndoMoveResponse Execute(UndoMoveRequest request)
    {
        try
        {
            // Check if the player requesting the undo is the current player and if it's their turn
            if (request.Game.CurrentTurn != request.Player)
            {
                return new UndoMoveResponse
                {
                    Success = false,
                    Message = "It's not your turn.",
                    Game = request.Game
                };
            }

            // Check if there are any moves to undo
            if (request.Game.Board.Moves.Count == 0)
            {
                return new UndoMoveResponse
                {
                    Success = false,
                    Message = "No moves to undo.",
                    Game = request.Game
                };
            }

            // Undo the last move
            request.Game.Board.UndoMove();

            return new UndoMoveResponse
            {
                Success = true,
                Game = request.Game
            };
        }
        catch (Exception ex)
        {
            return new UndoMoveResponse
            {
                Success = false,
                Message = ex.Message,
                Game = request.Game
            };
        }
    }
}