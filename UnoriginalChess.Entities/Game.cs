namespace UnoriginalChess.Entities;

public class Game
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
    public IDisplayBoard Display { get; set; }
    public Player CurrentTurn { get; private set; }
    public Player? Winner { get; set; }

    public void DisplayBoard()
    {
        Display.DisplayBoard(Board);
    }

    public bool CanMove(Move move)
    {
        if (!Board.IsCellOccupied(move.Start))
        {
            return false;
            // throw new InvalidMoveException("Start position does not contain a piece.");
        }
        
        if (Board.Cells[move.Start.Row][move.Start.Column].Piece?.Color != CurrentTurn.Color)
        {
            return false;
            // throw new InvalidMoveException($"{CurrentTurn.Color.ToString()} to move.");
        }
        
        if (!Board.GetLegalMoves(move.Start).Contains(move))
        {
            return false;
            // throw new InvalidMoveException("This is not a legal move.");
        }

        return true;
    }

    public void MakeMove(Move move)
    {
        CanMove(move);
        
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