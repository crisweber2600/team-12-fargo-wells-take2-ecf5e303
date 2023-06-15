using System;
using System.Drawing;
using FluentAssertions;
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
        Point currentPosition;

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

        [Given(@"the player chooses to move in (.*)")]
        public void givenPlayerChoosesDirection(String direction) {
            this.direction = (GameController.DIRECTION) Enum.Parse(typeof(GameController.DIRECTION) , direction);
        }

        [Given(@"the current move count is (.*)")]
        public void givenTheCurrentMoveCountIs(int currentMoveCount)
        {
            testObj.SetCurrentMoveCount(currentMoveCount);
        }

        [When(@"the character moves")]
        public void whenTheCharacterMoves()
        {
            testObj.SetCharacterPosition(new Point(this.startX, this.startY));
            testObj.Move(this.direction);
            GameController.GameStatus status = testObj.GetStatus();
            this.currentPosition = status.currentPosition;
        }

        [Then(@"the character is now at position with XCoordinates (.*)")]
        public void checkXCoordinates(int endX)
        {
            Assert.NotNull(this.currentPosition, "Expected position not null" );
            Assert.AreEqual(endX, this.currentPosition.X);
        }

        [Then(@"YCoordinates  (.*)")]
        public void checkYCoordinates(int endY)
        {
            Assert.NotNull(this.currentPosition, "Expected position not null");
            Assert.AreEqual(endY, this.currentPosition.Y);
        }

        [Then(@"the new move count is (.*)")]
        public void checkNewMoveCount(int endingMoveCount)
        {
            Assert.AreEqual(testObj.GetStatus().moveCount, endingMoveCount);
        }
    }
}