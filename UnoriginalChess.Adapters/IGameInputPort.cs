using UnoriginalChess.Entities;

namespace UnoriginalChess.Adapters;

public interface IGameInputPort
{
    Position ReadPosition();
}