using NUnit.Framework;

namespace levelup
{
    public class MonsterTests
    {
        private GameController gameController;
        private GameMap gameMap;

        [SetUp]
        public void Setup()
        {
            gameController = new GameController();
            gameMap = new GameMap();
        }

        [Test]
        public void Test_Monster_Spawned()
        {
            Assert.IsNotEmpty(gameMap.Monsters);
        }

        [Test]
        public void Test_Monster_Encounter()
        {
            // Start the game
            gameController.StartGame();

            // Move character to a position with a monster
            var monsterPosition = gameMap.Monsters[0].Position;
            gameController.SetCharacterPosition(monsterPosition.x, monsterPosition.y);

            // Check if an encounter is detected
            bool isEncounter = gameController.CheckForMonsterEncounter(monsterPosition);

            // Assert that an encounter is detected
            Assert.IsTrue(isEncounter);
        }


        [Test]
        public void Test_Monster_Encounter_None()
        {
            gameController.StartGame();

            var originalPosition = gameController.GetStatus().currentPosition;
            gameController.character.Position = new Position(0, 0);

            Assert.IsFalse(gameController.CheckForMonsterEncounter(gameController.GetStatus().currentPosition));

            // Resetting character position to original
            gameController.character.Position = originalPosition;
        }
    }
}