using UnoriginalChess.Adapters;
using UnoriginalChess.Application;
using UnoriginalChess.Entities;

namespace UnoriginalChess.Console;

public class UnoriginalConsoleChess
{
    private StartGameUseCase<string> _startGameUseCase;
    private MakeMoveUseCase<string> _makeMoveUseCase;
    private EndGameUseCase<string> _endGameUseCase;
    private Game _game;
    private Player _player1;
    private Player _player2;
    private IGameOutputPort<string> _presenter;
    private IGameInputPort _input;

    public UnoriginalConsoleChess()
    {
        _presenter = new ConsoleGamePresenter();
        _input = new ConsoleGameInputPort();
        _startGameUseCase = new StartGameUseCase<string>(_presenter);
        _makeMoveUseCase = new MakeMoveUseCase<string>(_presenter);
        _endGameUseCase = new EndGameUseCase<string>(_presenter);

        // Initialize players
        _player1 = new Player("Player1", PlayerColor.White);
        _player2 = new Player("Player2", PlayerColor.Black);
    }

    public void Run()
    {
        System.Console.WriteLine("Welcome to Unoriginal Chess!");

        // Start game
        var startGameRequest = new StartGameRequest { Players = new List<Player> { _player1, _player2 } };
        _game = _startGameUseCase.Execute(startGameRequest);

        while (!_game.IsGameOver)
        {
            // Display the current board
            string boardRepresentation = _presenter.FormatBoard(_game.Board);
            System.Console.WriteLine(boardRepresentation);
            
            // Get move from current player
            System.Console.WriteLine("Enter the start position of the piece you want to move: ");
            Position start = _input.GetPosition();
            System.Console.WriteLine("Enter the end position where you want to move the piece: ");
            Position end = _input.GetPosition();

            var moveRequest = new MakeMoveRequest
            {
                Game = _game,
                Player = _game.CurrentTurn,
                Start = start,
                End = end
            };

            // Make move
            string makeMoveResult = _makeMoveUseCase.Execute(moveRequest);
            System.Console.WriteLine(makeMoveResult);

            if (_game.IsPlayerInCheckmate(_player1) || _game.IsPlayerInCheckmate(_player2))
            {
                System.Console.WriteLine($"{_game.CurrentTurn.Name} is in checkmate.");
                string result = _endGameUseCase.Execute(new EndGameRequest { Game = _game });
                System.Console.WriteLine(result);
            }

            if (_game.IsPlayerInStalemate(_player1) || _game.IsPlayerInStalemate(_player2))
            {
                System.Console.WriteLine($"{_game.CurrentTurn.Name} is in stalemate.");
                string result = _endGameUseCase.Execute(new EndGameRequest { Game = _game });
                System.Console.WriteLine(result);
            }
        }
    }
}
