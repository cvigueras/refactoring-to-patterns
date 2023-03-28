using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveSouth : IMove
    {
        private readonly MarsRover _marsRover;

        public MoveSouth(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Move()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X}:{_marsRover.Y + 1}");
            _marsRover.Y = _marsRover.Y < 9 && !_marsRover.ObstacleFound ? _marsRover.Y += 1 : _marsRover.Y;
        }
    }
}