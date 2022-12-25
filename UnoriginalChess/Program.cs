using UnoriginalChess;

var players = new List<Player>();
var player1 = InputHandler.ReadPlayerName(PlayerColor.White, "Enter the name of player 1:");
var player2 = InputHandler.ReadPlayerName(PlayerColor.Black, "Enter the name of player 2:");
players.Add(player1);
players.Add(player2);

var display = new ConsoleDisplay();
var game = new Game(new Board(8, 8), players, display);

while (game.Winner is null)
{
    game.DisplayBoard();
    var player = game.CurrentTurn;

    Console.WriteLine($"{player.Name} to move. Enter your move:");
    Position start = InputHandler.ReadPosition("Start position: ");
    Position end = InputHandler.ReadPosition("End position: ");
    var move = new Move(start, end);

    // game.MakeMove(player, move);
}

// Display the final board
game.DisplayBoard();

// Display the winner, if any
if (game.Winner != null)
{
    Console.WriteLine($"{game.Winner.Name} wins!");
}
else
{
    Console.WriteLine("The game is a draw.");
}

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
        return new Position(input[1], input[0] - 'a');
    }
    
    internal static Player ReadPlayerName(PlayerColor color, string prompt)
    {
        Console.WriteLine(prompt);

        var name = Console.ReadLine();
        // TODO: Validate input and loop if invalid name is given

        return new Player(name, color);
    }
}

internal class UserQuitException : Exception
{
    public UserQuitException()
    {
        
    }

    public UserQuitException(string message) : base(message)
    {
        
    }

    public UserQuitException(string message, Exception innerException)
        : base(message, innerException)
    {
        
    }
}