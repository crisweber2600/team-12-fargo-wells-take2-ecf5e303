using LevelUpGame.levelup;
using NUnit.Framework;

namespace LevelUpGame.Test.levelup
{
    [TestFixture]
    public class CharacterTest
    {
        private MockCharacter? testObj;
        string arbitraryName = "Arbitrary Name";

        [SetUp]
        public void SetUp()
        {
            testObj = new MockCharacter(arbitraryName);
        }

        [Test]
        public void CharacterHasNameAndMoveCountWhenInitialized()
        {
            Assert.AreEqual(arbitraryName, testObj.Name);
            Assert.AreEqual(0, testObj.moveCount);
        }

        [Test]
        public void CharacterHasNewPositionOnEnterMap()
        {
            FakeGameMap m = new FakeGameMap();
            testObj.EnterMap(m);
            Assert.AreEqual(m.startingPosition, testObj.Position);
            Assert.AreEqual(m, testObj.gameMap);
        }

        [Test]
        public void CharacterHasNewPositionOnMove()
        {
            FakeGameMap m = new FakeGameMap();
            testObj.gameMap = m;
            testObj.Move(GameController.DIRECTION.NORTH);
            Assert.AreEqual(m.stubbedPosition.x, testObj.Position.x);

            Assert.AreEqual(m.stubbedPosition.y, testObj.Position.y);
        }

        [Test]
        public void CharacterIncrementsMoveCountOnMove()
        {
            testObj.gameMap = new FakeGameMap();
            testObj.Move(GameController.DIRECTION.SOUTH);
            Assert.AreEqual(1, testObj.moveCount);
        }
    }
}