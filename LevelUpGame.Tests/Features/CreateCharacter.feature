Feature: CreateCharacter
![Gamer](./gamerErin.png)
    I want to create a new custom character, setting their name

@acceptance 
Scenario Outline: Set character name
    Character creation is currently split to be very simple: the only customization is setting the name.

    Given the player supplies the name <characterNameInput>
    When the character is created
    Then the Game sets the character name to <characterNameOutput>
    Examples:

        | characterNameInput | characterNameOutput |
        | Erin            | Erin             |
        | | Character |
