using UnoriginalChess.Entities.Exceptions;

namespace UnoriginalChess.Entities;

internal static class InputHandler
{
    internal static Position ReadPosition(string prompt)
    {
        string? input;
        while (true)
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            input = input?.Trim().ToLower();
            
            if (string.Equals("q", input))
            {
                throw new UserQuitException();
            }
            else if (input.Length != 2)
            {
                Console.WriteLine("Input must be in the format [letter][number]. E.g.: E4");
            }
            else if (input[0] < 'a' || input[0] > 'h')
            {
                Console.WriteLine("Column must be a character between 'A' and 'H'.");
            }
            else if (!int.TryParse(input[1].ToString(), out int inputRow))
            {
                Console.WriteLine("Row must be an integer.");
            }
            else if (inputRow < 1 || inputRow > 8)
            {
                Console.WriteLine("Row must be a number between 1 and 8.");
            }
            else
            {
                break;
            }
        }
        return new Position(int.Parse(input[1].ToString()) - 1, input[0] - 'a');
    }
    
    internal static Player ReadPlayerName(PlayerColor color, string prompt)
    {
        Console.WriteLine(prompt);

        var name = Console.ReadLine();
        // TODO: Validate input and loop if invalid name is given

        return new Player(name, color);
    }
}