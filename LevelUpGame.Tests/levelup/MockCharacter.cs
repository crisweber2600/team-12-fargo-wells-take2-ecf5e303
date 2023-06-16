using LevelUpGame.levelup;

namespace LevelUpGame.Test.levelup
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
    }
}