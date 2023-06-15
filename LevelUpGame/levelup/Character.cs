namespace LevelUpGame.levelup
{
    public class Character
    {
        public readonly string DEFAULT_CHARACTER_NAME = "Character";
        public string name { get; set; }
        public int moveCount { get; set; }
        public int timesCalled {get; set; }
        public DIRECTION lastDirectionCalled {get; set; }
        public Position position {get; set; }

        public Character()
        {
            this.name = DEFAULT_CHARACTER_NAME;
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
            this.name = name;
        }
    }
}