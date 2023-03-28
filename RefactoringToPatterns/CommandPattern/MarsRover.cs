using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        public int X;
        public int Y;
        public bool ObstacleFound;
        private char _direction;
        public readonly string[] Obstacles;

        private readonly Movement _movement;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            X = x;
            Y = y;
            _direction = direction;
            Obstacles = obstacles;
            _movement = Movement.Create(this);
        }

        public void Execute(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                    {
                        var movement = _movement.Movements[_direction];
                        movement.Move();
                        break;
                    }
                    case 'L':
                        _direction = _movement.GetLeftDirection(_direction);
                        break;
                    case 'R':
                        _direction = _movement.GetRightDirection(_direction);
                        break;
                }
            }
        }
        public string GetState()
        {
            return !ObstacleFound ? $"{X}:{Y}:{_direction}" : $"O:{X}:{Y}:{_direction}";
        }
    }
}