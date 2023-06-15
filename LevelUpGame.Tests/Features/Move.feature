Feature: Move
    I want to move my character. If they attempt to move past a boundary, the move results in no change in position.

@acceptance
Scenario Outline: Move in a direction
    Simple example of how to test move

    Given the character starts at position with XCoordinates <startingPositionX>
    And starts at YCoordinates <startingPositionY>
    And the current move count is <startingMoveCount>
    And the player chooses to move in <direction>
    When the character moves
    Then the character is now at position with XCoordinates <endingPositionX>
    And YCoordinates  <endingPositionY>
    And ending move count <endingMoveCount>
    Examples:
        | startingPositionX | startingPositionY | startingMoveCount | direction | endingPositionX | endingPositionY | endingMoveCount | 
        | 0 | 0 | 0 | NORTH | 0 | 1 | 1 | 
        | 0                 | 0                 | 4                 | SOUTH     | 0               | 0               | 5               |
        | 5                 | 4                 | 97                | EAST      | 6               | 4               | 98               |
        | 9 | 4 | 33 | EAST | 9 | 4 | 34 |
        | 4 | 9 | 43 | NORTH | 4 | 9 | 44 |
