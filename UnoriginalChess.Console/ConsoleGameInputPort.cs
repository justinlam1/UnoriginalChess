using UnoriginalChess.Application;
using UnoriginalChess.Entities;

namespace UnoriginalChess.Console;

public class ConsoleGameInputPort : IGameInputPort
{
    public Position GetPosition()
    {
        while (true)
        {
            string? input = System.Console.ReadLine();
            try
            {
                return Position.FromChessCoordinates(input);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Invalid input: {ex.Message}");
            }
        }
    }
}