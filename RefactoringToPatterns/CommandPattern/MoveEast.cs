using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public interface IMove
    {
        void Move();
    }

    public class MoveEast : IMove
    {
        private readonly MarsRover _marsRover;

        public MoveEast(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Move()
        {
            _marsRover.ObstacleFound = _marsRover.Obstacles.Contains($"{_marsRover.X + 1}:{_marsRover.Y}");
            _marsRover.X = _marsRover.X < 9 && !_marsRover.ObstacleFound ? _marsRover.X += 1 : _marsRover.X;
        }
    }
}