using GenericRPG;
using GenericRPG.Core;

Game game = new Game(Console.OpenStandardInput(), Console.OpenStandardOutput());
game.GetNextLevel().Play();
