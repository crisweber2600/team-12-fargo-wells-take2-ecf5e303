using Sharprompt;
using System.Collections;
using System.Drawing;

namespace levelup.cli;

class Game
{
    static GameController gameController = new GameController();
    static List<GameController.GameStatus> gameHistory = new List<GameController.GameStatus>();
    static Boolean isGameStarted = false;

    public enum startingMenuCommands
    {
        Help,
        CreateCharacter,
        StartGame,
        Exit
    }

    public enum inGameCommands
    {
        Help,
        North,
        South,
        East,
        West,
        Exit
    }

    static void Main(string[] args)
    {
        printWelcomeMessage();

        while (!isGameStarted)
        {
            var type = Prompt.Select<startingMenuCommands>("Choose game command:");

            switch (type)
            {
                case startingMenuCommands.Help:
                    Help();
                    break;
                case startingMenuCommands.CreateCharacter:
                    CreateCharacter();
                    break;
                case startingMenuCommands.Exit:
                    EndGame();
                    break;
                case startingMenuCommands.StartGame:
                    StartGame();
                    printMap();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        while (true)
        {
            var type = Prompt.Select<inGameCommands>("Choose game command:");

            switch (type)
            {
                case inGameCommands.Help:
                    Help();
                    break;
                case inGameCommands.Exit:
                    EndGame();
                    break;
                case inGameCommands.North:
                    MoveNorth();
                    break;
                case inGameCommands.South:
                    MoveSouth();
                    break;
                case inGameCommands.East:
                    MoveEast();
                    break;
                case inGameCommands.West:
                    MoveWest();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            printMap();
        }
    }

    static void Help()
    {
        //TODO: FILL OUT USER HELP INSTRUCTIONS
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("HELP!");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Choose a command below using your arrow keys.");
        Console.WriteLine("Once a game is started, you will be able to move and explore.");
        Console.WriteLine("Once you are done exploring, choose Exit to see a summary.");
        Console.WriteLine("-------------------------------------------------");
    }

    private static void printWelcomeMessage()
    {
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("           |   Wells   |");
        Console.WriteLine("           |    of     |");
        Console.WriteLine("           |   Danger  |");
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Use your arrow keys to select a command below");
        Console.WriteLine("Create a character with a custom name.");
        Console.WriteLine("Then, start the game to start your adventure.");
        Console.WriteLine("-------------------------------------------------");
    }

    private static void printMap()
    {
        Console.Clear();
        Position currentPos = gameController.GetStatus().currentPosition;

        for (int i = 9; i >= 0; i--)
        {
            for (int j = 0; j < 10; j++)
            {
                if (currentPos.x == j && currentPos.y == i)
                {
                    Console.Write(" " + "X" + " ");
                }
                else
                {
                    Console.Write("░░░" + "");
                }
            }

            Console.WriteLine();
        }

        gameController.CheckForMonsterEncounter(currentPos);
    }

    private static bool IsPositionMonster(Position position)
    {
        foreach (var monster in gameController.gameMap.Monsters)
        {
            if (monster.Position.x == position.x && monster.Position.y == position.y)
            {
                return true;
            }
        }

        return false;
    }


    static void CreateCharacter()
    {
        var characterName = Prompt.Input<string>("What is your character's name?");
        gameController.CreateCharacter(characterName);
        var gameStatusCharacterName = gameController.GetStatus().characterName;
        Console.WriteLine($"Your character, {gameStatusCharacterName}, is created!");
    }

    static void StartGame()
    {
        isGameStarted = true;
        gameController.StartGame();
        // TODO: Update this prompt. Also, do you want to get the game status and tell
        // the player where their character is?
        Console.WriteLine("Welcome to Forests and Monsters! You have entered a mysterious place.");
    }

    static void MoveNorth()
    {
        gameController.Move(GameController.DIRECTION.NORTH);
        var status = gameController.GetStatus();
        updateStatus(status);

        gameController.CheckForMonsterEncounter(status.currentPosition);
    }

    static void MoveSouth()
    {
        gameController.Move(GameController.DIRECTION.SOUTH);
        var status = gameController.GetStatus();
        updateStatus(status);

        gameController.CheckForMonsterEncounter(status.currentPosition);
    }

    static void MoveEast()
    {
        gameController.Move(GameController.DIRECTION.EAST);
        var status = gameController.GetStatus();
        updateStatus(status);

        gameController.CheckForMonsterEncounter(status.currentPosition);
    }

    static void MoveWest()
    {
        gameController.Move(GameController.DIRECTION.WEST);
        var status = gameController.GetStatus();
        updateStatus(status);

        gameController.CheckForMonsterEncounter(status.currentPosition);
    }

    static void EndGame()
    {
        var answer = Prompt.Confirm("Do you want to exit?");
        if (answer == true)
        {
            //TODO: PRINT FINAL SUMMARY
            Console.WriteLine("You exit the mysterious world.");
            PrintSummary();
            Environment.Exit(0);
        }
    }

    static void PrintSummary()
    {
        Console.WriteLine("Exiting the mysterious land!");
        foreach (GameController.GameStatus status in gameHistory)
        {
            // TODO: Override toString on game status to print pretty
            Console.WriteLine(status);
        }
        // TODO: Print anything else you committed to in your mockup
    }

    private static void updateStatus(GameController.GameStatus status)
    {
        gameHistory.Add(status);
    }
}