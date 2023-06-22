using UnoriginalChess.Adapters;
using UnoriginalChess.Application;
using UnoriginalChess.Console;

var gamePresenter = new ConsoleGamePresenter();
var startGameUseCase = new StartGameUseCase();
var makeMoveUseCase = new MakeMoveUseCase();
var endGameUseCase = new EndGameUseCase();

var app = new UnoriginalConsoleChess(gamePresenter, startGameUseCase, makeMoveUseCase, endGameUseCase);

app.Run();