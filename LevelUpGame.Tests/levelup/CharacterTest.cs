using levelup;
using NUnit.Framework;

namespace levelup
{
    [TestFixture]
    public class CharacterTest
    {
        private Character? testObj;
        string arbitraryName = "Arbitrary Name";

        [SetUp]
        public void SetUp()
        {
            testObj = new Character(arbitraryName);
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
            Assert.AreEqual(m.stubbedPosition, testObj.Position);
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