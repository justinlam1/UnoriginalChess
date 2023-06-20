using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public class MakeMoveRequest
{
    public Game Game { get; set; }
    public Player Player { get; set; }
    public Position Start { get; set; }
    public Position End { get; set; }
}

public class MakeMoveResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public Game Game { get; set; }
}

public class MakeMoveUseCase
{
    public MakeMoveResponse Execute(MakeMoveRequest request)
    {
        try
        {
            if (request.Game.CurrentTurn != request.Player)
            {
                return new MakeMoveResponse
                {
                    Success = false,
                    Message = "It's not your turn.",
                    Game = request.Game
                };
            }
            
            // Check if the move is valid
            var piece = request.Game.Board.GetPieceAt(request.Start);
            if (piece == null || piece.Color != request.Player.Color)
            {
                return new MakeMoveResponse
                {
                    Success = false,
                    Message = "Invalid move.",
                    Game = request.Game
                };
            }

            var legalMoves = piece.GetLegalMoves(request.Game.Board);
            if (!legalMoves.Any(m => m.Equals(request.End)))
            {
                return new MakeMoveResponse
                {
                    Success = false,
                    Message = "Invalid move.",
                    Game = request.Game
                };
            }

            // Make the move
            request.Game.MovePiece(request.Start, request.End);
            return new MakeMoveResponse
            {
                Success = true,
                Game = request.Game
            };
        }
        catch (Exception ex)
        {
            return new MakeMoveResponse
            {
                Success = false,
                Message = ex.Message,
                Game = request.Game
            };
        }
    }
}
