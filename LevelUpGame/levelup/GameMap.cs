namespace levelup
{
    public class GameMap
    {
        public Position[,]? positions { get; set; }
        public Position? startingPosition { get; set; }

        public GameMap()
        {
            //TODO  
        }

        private void CreatePositions()
        {
            //TODO
        }

        public virtual Position CalculateNewPosition(Position currentPosition, GameController.DIRECTION direction)
        {
            Position newPos = new Position(-1, -1);
            //TODO

            return newPos;
        }

        public bool IsPositionValid(Position pos)
        {
            //TODO

            return false;
        }
    }
}