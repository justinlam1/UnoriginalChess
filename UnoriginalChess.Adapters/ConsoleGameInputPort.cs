using UnoriginalChess.Application;
using UnoriginalChess.Entities;

namespace UnoriginalChess.Adapters;

public class ConsoleGameInputPort : IGameInputPort
{
    public Position GetPosition()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            try
            {
                return Position.FromChessCoordinates(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
        }
    }
}