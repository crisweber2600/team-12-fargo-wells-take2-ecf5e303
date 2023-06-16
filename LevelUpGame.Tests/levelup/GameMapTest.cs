using levelup;
using NUnit.Framework;

namespace levelup
{
    [TestFixture]
    public class GameMapTest
    {
        private GameMap? testObj;

        [SetUp]
        public void SetUp()
        {
            testObj = new GameMap();
        }

        [Test]
        public void TestMapCreatesPositionsWhenInitialized()
        {
            Assert.NotNull(testObj.positions);
            Assert.AreEqual(100, testObj.positions.Length);
            Position samplePosition = testObj.positions[4,3];
            Assert.AreEqual(4, samplePosition.x);
            Assert.AreEqual(3, samplePosition.y);
            Assert.NotNull(testObj.startingPosition);
        }

        [Test]
        public void TestCalcPositionInCenterOfBoardEast()
        {
            Position startPos = testObj.positions[3,4];
            Position newPos = testObj.CalculateNewPosition(startPos, GameController.DIRECTION.EAST);
            Assert.AreEqual(4, newPos.x);
            Assert.AreEqual(startPos.y, newPos.y);
        }

        [Test]
        public void TestCalcPositionInCenterOfBoardWest()
        {
            Position startPos = testObj.positions[3, 4];
            Position newPos = testObj.CalculateNewPosition(startPos, GameController.DIRECTION.WEST);
            Assert.AreEqual(2, newPos.x);
            Assert.AreEqual(startPos.y, newPos.y);
        }

        [Test]
        public void TestCalcPositionInCenterOfBoardNorth()
        {
            Position startPos = testObj.positions[3, 4];
            Position newPos = testObj.CalculateNewPosition(startPos, GameController.DIRECTION.NORTH);
            Assert.AreEqual(startPos.x, newPos.x);
            Assert.AreEqual(5, newPos.y);
        }

        [Test]
        public void TestCalcPositionInCenterOfBoardSouth()
        {
            Position startPos = testObj.positions[3, 4];
            Position newPos = testObj.CalculateNewPosition(startPos, GameController.DIRECTION.SOUTH);
            Assert.AreEqual(startPos.x, newPos.x);
            Assert.AreEqual(3, newPos.y);
        }

        [Test]
        public void IsPositionValid()
        {
            Position valid = new Position(0,3);
            Assert.True(testObj.IsPositionValid(valid));
            valid = new Position(0, 0);
            Assert.True(testObj.IsPositionValid(valid));
            valid = new Position(3, 9);
            Assert.True(testObj.IsPositionValid(valid));
            Position inValidX = new Position(-1,5);
            Assert.False(testObj.IsPositionValid(inValidX));
            Position inValidY = new Position(1, -5);
            Assert.False(testObj.IsPositionValid(inValidY));
            Position inValidXAndY = new Position(11, 11);
            Assert.False(testObj.IsPositionValid(inValidXAndY));
        }

        [Test]
        public void TestCalcPositionOnBottomSouth()
        {
            Position startPos = testObj.positions[3, 0];
            Position newPos = testObj.CalculateNewPosition(startPos, GameController.DIRECTION.SOUTH);
            Assert.AreEqual(startPos.x, newPos.x);
            Assert.AreEqual(startPos.y, newPos.y);
        }

        
    }
}