using System.Drawing;

namespace UnoriginalChess;

internal class Player
{
    public Player(string name, PlayerColor color)
    {
        Name = name;
        Color = color;
    }
    
    public string Name { get; private set; } = null!;
    public PlayerColor Color { get; private set; }
    public int GamesWon { get; private set; }
    public int TotalGamesPlayed { get; private set; }

    internal bool MakeMove(Board board, Move move)
    {
        throw new NotImplementedException();
    }
}