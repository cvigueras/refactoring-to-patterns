using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveNorth : IMove
    {
        private readonly MarsRover _marsRover;

        public MoveNorth(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Move()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X}:{_marsRover.Y - 1}");
            _marsRover.Y = _marsRover.Y > 0 && !_marsRover.ObstacleFound ? _marsRover.Y -= 1 : _marsRover.Y;
        }
    }
}