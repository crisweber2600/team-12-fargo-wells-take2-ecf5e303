using System.Drawing;

namespace LevelUpGame.levelupGame.levelup
{
    public class GameController
    {
        public readonly string DEFAULT_CHARACTER_NAME = "Character";

        public record struct GameStatus(
            // TODO: Add other status data
            string characterName,
            Point currentPosition,
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

        public GameController()
        {
            status = new GameStatus
            {
                characterName = DEFAULT_CHARACTER_NAME,
                currentPosition = new Point(0, 0),
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
                    status.currentPosition = new Point(status.currentPosition.X, status.currentPosition.Y + 1);
                    break;
                case DIRECTION.SOUTH:
                    status.currentPosition = new Point(status.currentPosition.X, status.currentPosition.Y - 1);
                    break;
                case DIRECTION.EAST:
                    status.currentPosition = new Point(status.currentPosition.X - 1, status.currentPosition.Y);
                    break;
                case DIRECTION.WEST:
                    status.currentPosition = new Point(status.currentPosition.X + 1, status.currentPosition.Y);
                    break;
            }

            status.moveCount++;
        }

        public void SetCharacterPosition(Point coordinates)
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
    }
}