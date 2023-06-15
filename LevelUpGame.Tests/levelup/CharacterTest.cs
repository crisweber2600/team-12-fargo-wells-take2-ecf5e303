using NUnit.Framework;
using levelup;

namespace levelup
{
    [TestFixture]
    public class CharacterTest
    {
        private Character? testCharacter;

        [SetUp]
        public void SetUp()
        {
            testCharacter = new Character();
        }

        [Test]
        public void IsGameResultInitialized()
        {
        #pragma warning disable CS8602 // Rethrow to preserve stack details
            Assert.IsNotNull(testCharacter);
        }

        [Test]
        public void IsUsingPassedName()
        {
            string name = "TestCharacter";
            Character namedCharacter = new Character(name);
        #pragma warning disable CS8602 // Rethrow to preserve stack details
            Assert.AreEqual(namedCharacter.name, name);
        }
    }
}