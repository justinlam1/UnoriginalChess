using UnoriginalChess.Entities;

namespace UnoriginalChess.Application;

public interface IGameInputPort
{
    Position GetPosition();
}