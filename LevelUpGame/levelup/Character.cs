namespace LevelUpGame.levelup
{
    public class Character
    {
        public readonly string DEFAULT_CHARACTER_NAME = "Character";
        public GameMap? gameMap;
        public int moveCount { get; set; }
        public int timesCalled { get; set; }
        public GameController.DIRECTION lastDirectionCalled { get; set; }
        public Position position { get; set; }

        public Position Position { get; set; }
        public string Name { get; set; }

        public Character()
        {
            this.Name = DEFAULT_CHARACTER_NAME;
        }


        public Character(string name)
        {
            this.Name = name;
        }

        public void EnterMap(GameMap GameMap)
        {
            this.gameMap = GameMap;
        }

        public virtual void Move(GameController.DIRECTION direction)
        {
            if (this.gameMap != null)
            {
                this.Position = gameMap.CalculateNewPosition(this.Position, direction);
                this.moveCount += 1;
            }
            else
            {
                this.Position = null;
            }
        }
    }

    public class FakeGameMap : GameMap
    {
    }
}