namespace levelup
{
    public class Monster
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int Health { get; set; }

        public Monster(string name, Position position, int health)
        {
            this.Name = name;
            this.Position = position;
            this.Health = health;
        }
    }
}