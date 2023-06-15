using System.Drawing;

namespace LevelUpGame.levelup
{
    public class GameController
    {
        public readonly string DEFAULT_CHARACTER_NAME = "Character";

        public record struct GameStatus(
            // TODO: Add other status data
            string characterName,
            Position currentPosition,
            int moveCount
        );

        public enum DIRECTION
        {
            NORTH,
            SOUTH,
            EAST,
            WEST
        }

        private GameStatus status;
        public Character character;
        public GameMap gameMap;

        public GameController()
        {
            status = new GameStatus
            {
                characterName = DEFAULT_CHARACTER_NAME,
                currentPosition = new Position(0, 0),
                moveCount = 100
            };
        }

        public void CreateCharacter(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                status.characterName = name;
            }
            else
            {
                status.characterName = DEFAULT_CHARACTER_NAME;
            }
        }

        public void StartGame()
        {
            // TODO: Implement startGame - Should probably create positions and put the character on one
            // TODO: Should also update the game status?
        }

        public GameStatus GetStatus()
        {
            return status;
        }

        public void Move(DIRECTION directionToMove)
        {
            switch (directionToMove)
            {
                case DIRECTION.NORTH:
                    status.currentPosition = new Position(status.currentPosition.x, status.currentPosition.y + 1);
                    break;
                case DIRECTION.SOUTH:
                    status.currentPosition = new Position(status.currentPosition.x, status.currentPosition.y - 1);
                    break;
                case DIRECTION.EAST:
                    status.currentPosition = new Position(status.currentPosition.x - 1, status.currentPosition.y);
                    break;
                case DIRECTION.WEST:
                    status.currentPosition = new Position(status.currentPosition.x + 1, status.currentPosition.y);
                    break;
            }

            status.moveCount++;
        }

        public void SetCharacterPosition(Position coordinates)
        {
            status.currentPosition = coordinates;
        }

        public void SetCurrentMoveCount(int moveCount)
        {
            status.moveCount = moveCount;
        }

        public int GetTotalPositions()
        {
            // TODO: IMPLEMENT THIS TO GET THE TOTAL POSITIONS FROM THE MAP -- exists to be testable
            return -10;
        }

        public void SetMoveCount(int startingMoveCount)
        {
            throw new NotImplementedException();
        }
    }
}