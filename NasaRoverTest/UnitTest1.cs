using MarsRoverProblemSolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NasaRoverTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestScenario_13N()
        {
            Position position = new Position()
            {
                X = 1,
                Y = 2,
                Direction = Directions.N
            };

            var maxPoints = new int[2] { 5, 5 };
            var moves = "LMLMLMLMM";

            position.PlayRover(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            var expectedOutput = "1 3 N";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestScanrio_23S()
        {
            Position position = new Position()
            {
                X = 3,
                Y = 3,
                Direction = Directions.E
            };

            var maxPoints = new int[2] { 5, 5 };
            var moves = "MRRMMRMRRM";

            position.PlayRover(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            var expectedOutput = "2 3 S";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestScanrio_51E()
        {
            Position position = new Position()
            {
                X = 3,
                Y = 3,
                Direction = Directions.E
            };

            var maxPoints = new int[2] { 5, 5 };
            var moves = "MMRMMRMRRM";

            position.PlayRover(maxPoints, moves);

            var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
            var expectedOutput = "5 1 E";

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
