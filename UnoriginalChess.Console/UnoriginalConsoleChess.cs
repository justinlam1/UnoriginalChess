using UnoriginalChess.Adapters;
using UnoriginalChess.Application;
using UnoriginalChess.Entities;

namespace UnoriginalChess.Console;

public class UnoriginalConsoleChess
{
    private Game _game;
    private IGameOutputPort _gamePresenter;
    private StartGameUseCase _startGameUseCase;
    private MakeMoveUseCase _makeMoveUseCase;
    private EndGameUseCase _endGameUseCase;

    public UnoriginalConsoleChess(IGameOutputPort gamePresenter, StartGameUseCase startGameUseCase, MakeMoveUseCase makeMoveUseCase, EndGameUseCase endGameUseCase)
    {
        _gamePresenter = gamePresenter;
        _startGameUseCase = startGameUseCase;
        _makeMoveUseCase = makeMoveUseCase;
        _endGameUseCase = endGameUseCase;
    }

    public void Run()
    {
        // Start the game
        var startGameResponse = _startGameUseCase.Execute(new StartGameRequest
        {
            Players = new List<Player> {
                new Player("Player 1", PlayerColor.White),
                new Player("Player 2", PlayerColor.Black),
            }
        });

        if (!startGameResponse.Success)
        {
            System.Console.WriteLine("Failed to start game: " + startGameResponse.Message);
            return;
        }

        _game = startGameResponse.Game;
        _gamePresenter.DisplayStartGame(_game.Players[0], _game.Players[1]);
        _gamePresenter.DisplayBoard(_game.Board);

        while (!_game.IsGameOver)
        {
            // Ask current player for their move
            System.Console.WriteLine($"Player {_game.CurrentTurn.Name}'s turn. Enter your move (format: start end, like: e2 e4):");
            string moveInput = System.Console.ReadLine();
            while (string.IsNullOrEmpty(moveInput) || moveInput.Length != 5)
            {
                System.Console.WriteLine("Invalid input. Please try again.");
                moveInput = System.Console.ReadLine();
            }

            var input = moveInput.Split(' ');
            var start = PositionHelper.FromChessCoordinates(input[0]);
            var end = PositionHelper.FromChessCoordinates(input[1]);

            // If the input was invalid, continue the loop
            if (start == null || end == null)
            {
                System.Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            // Try to make the move
            var makeMoveResponse = _makeMoveUseCase.Execute(new MakeMoveRequest
            {
                Game = _game,
                Player = _game.CurrentTurn,
                Start = start.Value,
                End = end.Value
            });

            if (!makeMoveResponse.Success)
            {
                System.Console.WriteLine("Invalid move: " + makeMoveResponse.Message);
                continue;
            }

            _gamePresenter.DisplayMove(makeMoveResponse.Game.Board.Moves.Peek());
            _gamePresenter.DisplayBoard(makeMoveResponse.Game.Board);

            // Check if game has ended
            if (_game.Winner != null)
            {
                var endGameResponse = _endGameUseCase.Execute(new EndGameRequest
                {
                    Game = _game
                });
                
                if (endGameResponse.Success)
                {
                    _gamePresenter.DisplayEndGame(_game.Winner);
                }
            }
            else if (_game.IsPlayerInStalemate(_game.CurrentTurn))
            {
                var endGameResponse = _endGameUseCase.Execute(new EndGameRequest
                {
                    Game = _game
                });

                if (endGameResponse.Success)
                {
                    _gamePresenter.DisplayDrawGame();
                }
            }
        }
    }
}
