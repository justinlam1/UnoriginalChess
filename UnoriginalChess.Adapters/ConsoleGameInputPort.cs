using UnoriginalChess.Entities;

namespace UnoriginalChess.Adapters;

public class ConsoleGameInputPort : IGameInputPort
{
    public Position ReadPosition()
    {
        Console.Write("Enter the position (row,column): ");
        var input = Console.ReadLine().Split(',');

        int row = Convert.ToInt32(input[0]);
        int column = Convert.ToInt32(input[1]);

        return new Position(row, column);
    }
}