using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

    public interface IGameOutputPort
    {
        void DisplayBoard(Board board, bool isFlipped = false);
        void DisplayMessage(string message);
    }
