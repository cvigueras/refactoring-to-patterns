using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveWest : IMove
    {
        private readonly MarsRover _marsRover;

        public MoveWest(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Move()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X - 1}:{_marsRover.Y}");
            _marsRover.X = _marsRover.X > 0 && !_marsRover.ObstacleFound ? _marsRover.X -= 1 : _marsRover.X;
        }
    }
}