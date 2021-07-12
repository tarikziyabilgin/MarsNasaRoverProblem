using System;

namespace MarsRoverProblemSolution
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] maxCoordinates = new Plateu().ReadInputForPlateau();
            var quit = "";
            do
            {
                try
                {
                    var position = new Position();
                    position.StartRover(maxCoordinates);
                    ConsoleHelper.WriteSucceedMessage($"{position.X} {position.Y} {position.Direction.ToString()}");
                    ConsoleHelper.WriteErrorMessage("Enter Q to exit... Other commands continue the game.");
                    quit = Console.ReadLine().ToUpper();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!quit.Equals("Q"));
            Console.ReadLine();
        }
    }
}
