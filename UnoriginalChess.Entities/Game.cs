using UnoriginalChess.Entities.Exceptions;

namespace UnoriginalChess.Entities;

public class Game
{
    public Game(Board board, List<Player> players, IDisplayBoard display)
    {
        if (players.Count < 2)
        {
            throw new ArgumentException("At least two players are required to start a game.", nameof(players));
        }
        
        Board = board;
        Players = players;
        Display = display;

        CurrentTurn = players.First();
    }
    
    public Board Board { get; private set; }
    public List<Player> Players { get; private set; }
    public IDisplayBoard Display { get; set; }
    public Player CurrentTurn { get; private set; }
    public Player? Winner { get; set; }

    public void DisplayBoard()
    {
        Display.DisplayBoard(Board);
    }

    public void MovePiece(Position start, Position end)
    {
        var piece = Board.GetPieceAt(start);
        if (piece == null || piece.Color != CurrentTurn.Color)
        {
            throw new InvalidMoveException("It's not your turn, or the move is invalid.");
        }
        
        var legalMoves = piece.GetLegalMoves(Board);
        if (!legalMoves.Contains(end))
        {
            throw new InvalidMoveException("This move is not legal.");
        }

        Board.MovePiece(start, end);

        // Check for checkmate or stalemate after each move
        if (IsPlayerInCheckmate(CurrentTurn))
        {
            // Handle checkmate
        }
        else if (IsPlayerInStalemate(CurrentTurn))
        {
            // Handle stalemate
        }

        // If the move was successful, it's the next player's turn
        RotateCurrentTurn();
    }

    private void RotateCurrentTurn()
    {
        // Cycle the current player
        var nextPlayerIndex = (Players.IndexOf(CurrentTurn) + 1) % Players.Count;
        CurrentTurn = Players.ElementAt(nextPlayerIndex);
    }
    
    public bool IsKingInCheck(Player currentPlayer)
    {
        var opposingPlayer = Players.First(p => p != currentPlayer);
        var kingPosition = Board.GetKingPosition(currentPlayer);

        foreach (var piece in Board.GetPieces(opposingPlayer))
        {
            var legalMoves = piece.GetLegalMoves(Board);
            if (legalMoves.Any(position => position.Equals(kingPosition)))
            {
                return true;
            }
        }
    
        return false;
    }
    
    public bool IsPlayerInCheckmate(Player currentPlayer)
    {
        if (!IsKingInCheck(currentPlayer))
        {
            return false;
        }

        // Check if the player has any legal moves that would get their king out of check
        foreach (var piece in Board.GetPieces(currentPlayer))
        {
            var legalMoves = piece.GetLegalMoves(Board);
            foreach (var position in legalMoves)
            {
                // Simulate the move and see if it gets the king out of check
                Board.MovePiece(piece.Position, position);
                var isStillInCheck = IsKingInCheck(currentPlayer);
                Board.UndoMove();

                if (!isStillInCheck)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool IsPlayerInStalemate(Player currentPlayer)
    {
        if (IsKingInCheck(currentPlayer))
        {
            return false;
        }

        // Check if the player has any legal moves
        foreach (var piece in Board.GetPieces(currentPlayer))
        {
            var legalMoves = piece.GetLegalMoves(Board);
            if (legalMoves.Any())
            {
                return false;
            }
        }

        return true;
    }

}