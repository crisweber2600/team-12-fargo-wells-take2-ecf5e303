using System;
using FluentAssertions;
using LevelUpGame.levelup;
using TechTalk.SpecFlow;

namespace LevelUpGame.Test.Steps;

[Binding]
public class GameSteps
{
    // private readonly ScenarioContext _scenarioContext;
    private GameController testObj = new GameController();

    private String characterName = "";

    public GameSteps(ScenarioContext scenarioContext)
    {
        //   _scenarioContext = scenarioContext;
    }

    [Given(@"the character's name is (.*)")]
    public void GivenTheCharactersNameIs(string characterNameInput)
    {
        this.characterName = characterNameInput;
    }

    [When(@"the player sets their name")]
    public void whenThePlayerSetsTheirName()
    {
        testObj = new GameController();
        testObj.CreateCharacter(characterName);
    }

    [Then(@"the Game sets the character's name to (.*)")]
    public void ThenTheResultShouldBe(string characterNameOutput)
    {
        testObj.GetStatus().characterName.Should().Be(characterNameOutput);
    }
}