using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public interface IGameOutputPort<T>
{
    T FormatBoard(Board board, bool isFlipped = false);
    T FormatMessage(string message);
}
