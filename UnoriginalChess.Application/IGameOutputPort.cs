using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public interface IGameOutputPort
{
    void DisplayBoard(Board board);
    void DisplayMessage(string message);
}
