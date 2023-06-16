namespace levelup
{
    public class CombatEntity
    {
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
    }


    public class Character : CombatEntity
    {
        public string? Name { get; set; }
        public Position? Position { get; set; }
        public GameMap? gameMap { get; set; }

        public int moveCount { get; set; }

        public Character(string name)
        {
            this.Name = name;
            this.moveCount = 0;
            this.Position = new Position(0, 0);
        }

        public Character()
        {
            this.Name = "";
            this.moveCount = 0;
            this.Position = new Position(0, 0);
        }

        public void EnterMap(GameMap map)
        {
            this.gameMap = map;
            this.Position = map.startingPosition;
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
}