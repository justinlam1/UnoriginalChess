using UnoriginalChess;
using UnoriginalChess.Exceptions;

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

    try
    {
        game.MakeMove(player, move);
    }
    catch (InvalidMoveException e)
    {
        Console.WriteLine($"Invalid move attempted: {e.Message}");
    }
    
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