namespace levelup
{
    public class GameController
    {
        public readonly string DEFAULT_CHARACTER_NAME = "Character";
        public Character? character { get; set; }
        public GameMap? gameMap { get; set; }

        public record struct GameStatus(
            // TODO: Add other status data
            String characterName,
            Position currentPosition,
            int moveCount
        );

        // TODO: Ensure this AND CLI commands match domain model
        public enum DIRECTION
        {
            NORTH,
            SOUTH,
            EAST,
            WEST
        }

        public bool CheckForMonsterEncounter(Position position)
        {
            foreach (var monster in gameMap.Monsters)
            {
                if (monster.Position.x == position.x && monster.Position.y == position.y)
                {
                    Console.WriteLine($"You've encountered a {monster.Name}!");
                    // Handle combat here if needed
                    return true;
                }
            }

            return false;
        }

        GameStatus status = new GameStatus();

        public GameController()
        {
            status.characterName = DEFAULT_CHARACTER_NAME;
            //Set current position to a nonsense place until you figure out who should initialize
            status.currentPosition = new Position(-1, -1);
            status.moveCount = 0;
        }

        public void CreateCharacter(String name)
        {
            if (name != null && !name.Equals(""))
            {
                this.character = new Character(name);
            }
            else
            {
                this.character = new Character(DEFAULT_CHARACTER_NAME);
            }

            this.status.characterName = character.Name;
        }


        public void ResolveCombat(Monster monster)
        {
            while (character.Health > 0 && monster.Health > 0)
            {
                // Character attacks monster
                Attack(character, monster);

                // Monster attacks character if it's still alive
                if (monster.Health > 0)
                {
                    Attack(monster, character);
                }
            }
        }

        public void Attack(CombatEntity attacker, CombatEntity defender)
        {
            int damage = Math.Max(0, attacker.AttackPower - defender.DefensePower);
            defender.Health -= damage;

            if (defender.Health <= 0)
            {
                // Defender is defeated
                // Reward the character or handle defeat
            }
        }

        public void StartGame()
        {
            gameMap = new GameMap();
            if (character == null)
            {
                CreateCharacter("");
            }

            character.EnterMap(gameMap);
            this.status.characterName = character.Name;
            this.status.currentPosition = character.Position;
        }

        public GameStatus GetStatus()
        {
            return this.status;
        }

        public void Move(DIRECTION directionToMove)
        {
            character.Move(directionToMove);
            this.status.currentPosition = character.Position;
            this.status.moveCount = character.moveCount;
            if (CheckForMonsterEncounter(character.Position))
            {
                var monster = GetMonsterAtPosition(character.Position);
                if (monster != null)
                {
                    ResolveCombat(monster);
                }
            }
        }

        public Monster GetMonsterAtPosition(Position position)
        {
            foreach (var monster in gameMap.Monsters)
            {
                if (monster.Position.x == position.x && monster.Position.y == position.y)
                {
                    return monster;
                }
            }

            return null;
        }

        public void SetCharacterPosition(int x, int y)
        {
            character.Position = new Position(x, y);
            this.status.currentPosition = character.Position;
        }

        public void SetMoveCount(int moveCount)
        {
            character.moveCount = moveCount;
            this.status.moveCount = character.moveCount;
        }
    }
}