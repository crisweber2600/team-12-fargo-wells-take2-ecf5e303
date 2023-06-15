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

        public virtual void Move(GameController.DIRECTION direction)
        {
            this.lastDirectionCalled = direction;
            this.timesCalled++;
            this.Position = new Position(3, 4);
            this.moveCount = 3;
        }

        public Character(string name)
        {
            this.Name = name;
        }

        public void EnterMap(GameMap GameMap)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeGameMap : GameMap
    {
    }
}