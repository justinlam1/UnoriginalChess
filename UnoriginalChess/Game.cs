using UnoriginalChess.Exceptions;

namespace UnoriginalChess;

internal class Game
{
    public Game(Board board, List<Player> players, IDisplayBoard display)
    {
        Board = board;
        Players = players;
        Display = display;

        CurrentTurn = players.First();
    }
    
    public Board Board { get; private set; }
    public List<Player> Players { get; private set; }
    public IDisplayBoard Display { get; private set; }
    public Player CurrentTurn { get; private set; }
    public Player? Winner { get; set; }

    public void DisplayBoard()
    {
        Display.DisplayBoard(Board);
    }

    public void MakeMove(Player player, Move move)
    {
        var pieceAtStart = Board.Cells[move.Start.Row][move.Start.Column].Piece;
        if (pieceAtStart == null)
        {
            throw new InvalidMoveException("No piece exists at start position.");
        }
        else if (pieceAtStart.Color != CurrentTurn.Color)
        {
            throw new InvalidMoveException("The piece at the starting location belongs to another player.");
        }
        
        // TODO: Add additional checks for valid move
        Board.UpdateBoard(move);

        RotateCurrentTurn();
    }

    private void RotateCurrentTurn()
    {
        // Cycle the current player
        var nextPlayerIndex = (Players.IndexOf(CurrentTurn) + 1) % Players.Count;
        CurrentTurn = Players.ElementAt(nextPlayerIndex);
    }
}