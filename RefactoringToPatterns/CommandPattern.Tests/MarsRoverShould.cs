using Xunit;

namespace RefactoringToPatterns.CommandPattern.Tests
{
    public class MarsRoverShould
    {
        [Fact]
        public void AcceptAnInitialState()
        {
            MarsRover marsRover = new MarsRover(0, 0, 'E', new string[] { });

            Assert.Equal("0:0:E", marsRover.GetState());
        }

        [Theory]
        [InlineData(0, 0, 'E', "M", "1:0:E")]
        [InlineData(0, 0, 'S', "M", "0:1:S")]
        [InlineData(1, 0, 'W', "M", "0:0:W")]
        [InlineData(0, 1, 'N', "M", "0:0:N")]
        public void MoveOneCellForward(int x, int y, char direction, string commands, string expectedFinalState)
        {
            MarsRover marsRover = new MarsRover(x, y, direction, new string[] { });

            marsRover.Execute(commands);

            Assert.Equal(expectedFinalState, marsRover.GetState());
        }
        
        [Theory]
        [InlineData(0, 0, 'N', "M", "0:0:N")]
        [InlineData(0, 0, 'W', "M", "0:0:W")]
        [InlineData(9, 0, 'E', "M", "9:0:E")]
        [InlineData(0, 9, 'S', "M", "0:9:S")]
        public void WrapAroundTheEdgesOfThePlateau(int x, int y, char direction, string commands, string expectedFinalState)
        {
            MarsRover marsRover = new MarsRover(x, y, direction, new string[] { });

            marsRover.Execute(commands);

            Assert.Equal(expectedFinalState, marsRover.GetState());
        }
        
        [Theory]
        [InlineData("L", "0:0:N")]
        [InlineData("LL", "0:0:W")]
        [InlineData("LLL", "0:0:S")]
        [InlineData("LLLL", "0:0:E")]
        [InlineData("R", "0:0:S")]
        [InlineData("RR", "0:0:W")]
        [InlineData("RRR", "0:0:N")]
        [InlineData("RRRR", "0:0:E")]
        public void RotateLeftAndRight(string commands, string expectedFinalState)
        {
            MarsRover marsRover = new MarsRover(0, 0, 'E', new string[] { });

            marsRover.Execute(commands);

            Assert.Equal(expectedFinalState, marsRover.GetState());
        }

        [Theory]
        [InlineData(0, 0, 'E', "MMM", new[] { "3:0" }, "O:2:0:E")]
        [InlineData(0, 0, 'S', "MMM", new[] { "0:3" }, "O:0:2:S")]
        [InlineData(9, 0, 'W', "MMM", new[] { "7:0" }, "O:8:0:W")]
        [InlineData(0, 9, 'N', "MMM", new[] { "0:7" }, "O:0:8:N")]
        public void StopAndReportIfAnObstacleIsFound(int x, int y, char direction, string commands, string[] obstacles, string expectedFinalState)
        {
            MarsRover marsRover = new MarsRover(x, y, direction, obstacles);

            marsRover.Execute(commands);

            Assert.Equal(expectedFinalState, marsRover.GetState());            
        }
    }
}