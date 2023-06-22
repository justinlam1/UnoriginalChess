using UnoriginalChess.Entities;

namespace UnoriginalChess.Adapters;

public interface IGameOutputPort
{
    void DisplayStartGame(Player player1, Player player2);
    void DisplayMove(Move move);
    void DisplayInvalidMove(Move move, string reason);
    void DisplayEndGame(Player winningPlayer);
    void DisplayDrawGame();
    void DisplayUndoMove(Move move);
    void DisplayBoard(Board board);
}