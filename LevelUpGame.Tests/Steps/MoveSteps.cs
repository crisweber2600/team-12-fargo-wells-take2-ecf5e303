using System;
using levelup;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DotNetExample.Tests.Steps
{
    [Binding]
    public class MoveSteps
    {
        GameController testObj = new GameController();
        int startX, startY;
        GameController.DIRECTION direction;
        int currentPositionX, currentPositionY, startingMoveCount;

        [Given(@"the character starts at position with XCoordinates (.*)")]
        public void givenTheCharacterStartsAtX(int startX)
        {
            this.startX = startX;
        }

        [Given(@"starts at YCoordinates (.*)")]
        public void givenTheCharacterStartsAtY(int startY)
        {
            this.startY = startY;
        }

        [Given(@"the current move count is (.*)")]
        public void givenTheCurrentMoveCountIs(int moveCount)
        {
            this.startingMoveCount = moveCount;
        }

        [Given(@"the player chooses to move in (.*)")]
        public void givenPlayerChoosesDirection(String direction) {
            this.direction = (GameController.DIRECTION) Enum.Parse(typeof(GameController.DIRECTION) , direction);
        }

        [When(@"the character moves")]
        public void whenTheCharacterMoves()
        {
            testObj.CreateCharacter("");
            testObj.StartGame();
            testObj.SetCharacterPosition(this.startX, this.startY);
            testObj.SetMoveCount(this.startingMoveCount);
            testObj.Move(this.direction);
            GameController.GameStatus status = testObj.GetStatus();
            this.currentPositionX = status.currentPosition.x;
            this.currentPositionY = status.currentPosition.y;
        }

        [Then(@"the character is now at position with XCoordinates (.*)")]
        public void checkXCoordinates(int endX)
        {
            Assert.NotNull(this.currentPositionX, "Expected position not null" );
            Assert.AreEqual(endX, this.currentPositionX);
        }

        [Then(@"YCoordinates  (.*)")]
        public void checkYCoordinates(int endY)
        {
            Assert.NotNull(this.currentPositionY, "Expected position not null");
            Assert.AreEqual(endY, this.currentPositionY);
        }

        [Then(@"ending move count (.*)")]
        public void givenTheEndingMoveCountIs(int moveCount)
        {
            Assert.AreEqual(moveCount, testObj.GetStatus().moveCount);
        }
    }
}