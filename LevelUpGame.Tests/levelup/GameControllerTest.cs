using NUnit.Framework;
using levelup;
using static levelup.GameController;
using System.Drawing;

namespace levelup
{
    [TestFixture]
    public class GameControllerTest
    {
        private GameController? gameController;

        [SetUp]
        public void SetUp()
        {
            gameController = new GameController();
        }

        [Test]
        public void IsGameResultInitialized()
        {
#pragma warning disable CS8602 // Rethrow to preserve stack details
            Assert.IsNotNull(gameController.GetStatus());
        }

        [Test]
        public void CreateCharacter_DefaultName_StatusCharacterNameIsDefaultCharacterName()
        {
            // Arrange
            string expectedName = gameController.DEFAULT_CHARACTER_NAME;

            // Act
            gameController.CreateCharacter(null);
            GameStatus status = gameController.GetStatus();

            // Assert
            Assert.AreEqual(expectedName, status.characterName);
        }

        [Test]
        public void CreateCharacter_CustomName_StatusCharacterNameIsCustomName()
        {
            // Arrange
            string customName = "John";

            // Act
            gameController.CreateCharacter(customName);
            GameStatus status = gameController.GetStatus();

            // Assert
            Assert.AreEqual(customName, status.characterName);
        }

        [Test]
        public void Move_North_CurrentPositionYIncreasesBy1()
        {
            // Arrange
            Point initialPosition = new Point(0, 0);
            gameController.SetCharacterPosition(initialPosition);

            // Act
            gameController.Move(GameController.DIRECTION.NORTH);
            GameStatus status = gameController.GetStatus();

            // Assert
            Assert.AreEqual(initialPosition.X, status.currentPosition.X);
            Assert.AreEqual(initialPosition.Y + 1, status.currentPosition.Y);
        }

        [Test]
        public void Move_South_CurrentPositionYIncreasesBy1()
        {
            // Arrange
            Point initialPosition = new Point(0, 0);
            gameController.SetCharacterPosition(initialPosition);

            // Act
            gameController.Move(GameController.DIRECTION.SOUTH);
            GameStatus status = gameController.GetStatus();

            // Assert
            Assert.AreEqual(initialPosition.X, status.currentPosition.X);
            Assert.AreEqual(initialPosition.Y - 1, status.currentPosition.Y);
        }

        [Test]
        public void Move_East_CurrentPositionXDecreasesBy1()
        {
            // Arrange
            Point initialPosition = new Point(0, 0);
            gameController.SetCharacterPosition(initialPosition);

            // Act
            gameController.Move(GameController.DIRECTION.EAST);
            GameStatus status = gameController.GetStatus();

            // Assert
            Assert.AreEqual(initialPosition.X - 1, status.currentPosition.X);
            Assert.AreEqual(initialPosition.Y, status.currentPosition.Y);
        }

        [Test]
        public void Move_West_CurrentPositionXIncreasesBy1()
        {
            // Arrange
            Point initialPosition = new Point(0, 0);
            gameController.SetCharacterPosition(initialPosition);

            // Act
            gameController.Move(GameController.DIRECTION.WEST);
            GameStatus status = gameController.GetStatus();

            // Assert
            Assert.AreEqual(initialPosition.X + 1, status.currentPosition.X);
            Assert.AreEqual(initialPosition.Y, status.currentPosition.Y);
        }

        [Test]
        public void GetTotalPositions_Default_ReturnsNegativeTen()
        {
            // Act
            int totalPositions = gameController.GetTotalPositions();

            // Assert
            Assert.AreEqual(-10, totalPositions);
        }
    }
}