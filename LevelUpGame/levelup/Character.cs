using System.Drawing;

namespace levelup
{
    public class Character
    {
        public readonly string DEFAULT_CHARACTER_NAME = "Character";
        public string name {get; set;}
        public Character()
        {
            this.name = DEFAULT_CHARACTER_NAME;
        }
        public Character(string name)
        {
            this.name = name;
        }

    }
}