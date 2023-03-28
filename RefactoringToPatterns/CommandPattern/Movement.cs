using System.Collections.Generic;
using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class Movement
    {
        public readonly Dictionary<char, IMove> Movements = new Dictionary<char, IMove>();
        public readonly Dictionary<char, char> MovementsLeft = new Dictionary<char, char>();
        public readonly Dictionary<char, char> MovementsRight = new Dictionary<char, char>();

        protected Movement(MarsRover marsRover)
        {
            Movements.Add('E', new MoveEast(marsRover));
            Movements.Add('W', new MoveWest(marsRover));
            Movements.Add('N', new MoveNorth(marsRover));
            Movements.Add('S', new MoveSouth(marsRover));
            MovementsLeft.Add('N', 'W');
            MovementsLeft.Add('E', 'N');
            MovementsLeft.Add('S', 'E');
            MovementsLeft.Add('W', 'S');
            MovementsRight.Add('N', 'E');
            MovementsRight.Add('E', 'S');
            MovementsRight.Add('S', 'W');
            MovementsRight.Add('W', 'N');
        }

        public static Movement Create(MarsRover marsRover)
        {
            return new Movement(marsRover);
        }

        public char GetLeftDirection(char direction)
        {
            return MovementsLeft.Where(x => x.Key.Equals(direction))
                .Select(x => x.Value).FirstOrDefault();
        }

        public char GetRightDirection(char direction)
        {
            return MovementsRight.Where(x => x.Key.Equals(direction))
                .Select(x => x.Value).FirstOrDefault();
        }
    }
}