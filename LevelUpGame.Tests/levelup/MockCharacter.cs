
namespace levelup
{
    public class MockCharacter : Character
    {
        public GameController.DIRECTION? lastDirectionCalled;
        public int timesCalled = 0;

        public MockCharacter(string name)
        {
            this.Name = name;
            this.timesCalled = 0;
            this.moveCount = 0;
        }

        public override void Move(GameController.DIRECTION direction)
        {
            this.lastDirectionCalled = direction;
            this.timesCalled++;
            this.Position = new Position(3,4);
            this.moveCount = 3;
        }

    }
}