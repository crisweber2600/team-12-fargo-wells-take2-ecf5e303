Feature: Game
![Gamer](./gamerErin.png)
    I want to create a new custom character, setting their name

@acceptance 
Scenario Outline: Set player name
    Character creation is currently split to be very simple: the only customization is setting the name.

    Given the character's name is <characterNameInput>
    When the player sets their name
    Then the Game sets the character's name to <characterNameOutput>
    Examples:

        | characterNameInput | characterNameOutput |  
        | Erin            | Erin             |
        |                 | Character           |