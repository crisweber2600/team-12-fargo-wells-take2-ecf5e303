using System;
using System.Collections.Generic;
using LevelUpGame.levelup;
using Sharprompt;

namespace LevelUpGame.Test.levelup
{
    class Game
    {
        static GameController gameController = new GameController();
        static List<GameController.GameStatus> gameHistory = new List<GameController.GameStatus>();
        static bool isGameStarted = false;

        public enum StartingMenuCommands
        {
            Help,
            CreateCharacter,
            StartGame,
            Exit
        }

        public enum InGameCommands
        {
            Help,
            North,
            South,
            East,
            West,
            Exit
        }


        static void Help()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("HELP!");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Choose a command below using your arrow keys.");
            Console.WriteLine("Once a game is started, you will be able to move and explore.");
            Console.WriteLine("Once you are done exploring, choose Exit to see a summary.");
            Console.WriteLine("-------------------------------------------------");
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("LEVEL UP GAMES");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Use your arrow keys to select a command below");
            Console.WriteLine("Create a character with a custom name.");
            Console.WriteLine("Then, start the game to begin your adventure.");
            Console.WriteLine("-------------------------------------------------");
        }

        static void CreateCharacter()
        {
            var characterName = Prompt.Input<string>("What is your character's name?");
            gameController.CreateCharacter(characterName);
            var gameStatusCharacterName = gameController.GetStatus().characterName;
            Console.WriteLine($"Your character, {gameStatusCharacterName}, has been created!");
        }

        static void StartGame()
        {
            isGameStarted = true;
            gameController.StartGame();
            Console.WriteLine("Welcome to Forests and Monsters! You have entered a mysterious place.");
        }

        static void MoveNorth()
        {
            gameController.Move(GameController.DIRECTION.NORTH);
            UpdateStatus(gameController.GetStatus());
        }

        static void MoveSouth()
        {
            gameController.Move(GameController.DIRECTION.SOUTH);
            UpdateStatus(gameController.GetStatus());
        }

        static void MoveEast()
        {
            gameController.Move(GameController.DIRECTION.EAST);
            UpdateStatus(gameController.GetStatus());
        }

        static void MoveWest()
        {
            gameController.Move(GameController.DIRECTION.WEST);
            UpdateStatus(gameController.GetStatus());
        }

        static void EndGame()
        {
            var answer = Prompt.Confirm("Do you want to exit?");
            if (answer)
            {
                Console.WriteLine("Exiting the mysterious world.");
                PrintSummary();
                Environment.Exit(0);
            }
        }

        static void PrintSummary()
        {
            Console.WriteLine("Exiting the mysterious land!");
            foreach (GameController.GameStatus status in gameHistory)
            {
                Console.WriteLine(
                    $"Character: {status.characterName}, Position: ({status.currentPosition.x}, {status.currentPosition.y}), Moves: {status.moveCount}");
            }
        }

        private static void UpdateStatus(GameController.GameStatus status)
        {
            gameHistory.Add(status);
        }
    }
}