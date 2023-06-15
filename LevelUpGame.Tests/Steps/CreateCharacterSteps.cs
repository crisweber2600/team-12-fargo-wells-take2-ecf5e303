using System;
using FluentAssertions;
using levelup;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DotNetExample.Tests.Steps
{
    [Binding]
    public class CreateCharacterSteps
    {
        private GameController testObj = new GameController();

        private String characterName = "";

        [Given(@"the player supplies the name (.*)")]
        public void GivenTheCharactersNameIs(string characterNameInput)
        {
            this.characterName = characterNameInput;
        }

        [When(@"the character is created")]
        public void whenThePlayerSetsTheirName()
        {
            testObj = new GameController();
            testObj.CreateCharacter(characterName);
        }
        
        [Then(@"the Game sets the character name to (.*)")]
        public void ThenTheResultShouldBe(string characterNameOutput)
        {
            testObj.GetStatus().characterName.Should().Be(characterNameOutput);
        }
    }
}