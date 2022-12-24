namespace UnoriginalChess;

internal class Game
{
    public Board Board { get; private set; }
    public Player CurrentTurn { get; private set; }
    public List<Player> Players { get; private set; }

    public Game(Board board, List<Player> players, IDisplayBoard display)
    {
        throw new NotImplementedException();
    }
}