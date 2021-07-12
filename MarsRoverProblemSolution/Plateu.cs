using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverProblemSolution
{
    public class Plateu
    {
        public int[] ReadInputForPlateau()
        {
            string[] maxCoordinates = null;
            while (!ValidateMaxCoordinates(maxCoordinates))
            {
                Console.WriteLine("Please Enter Upper-right Coordinates Of The Plateau:");
                maxCoordinates = Console.ReadLine()?.Trim().Split(' ');
            }
            return maxCoordinates.Select(m => Convert.ToInt32(m)).ToArray();
        }

        private bool ValidateMaxCoordinates(string[] maxCoordinates)
        {
            var errMessage = "Please Enter 2 Numeric Value With Space Seperated For Upper-right Coordinates Of The Plateau:";
            if (maxCoordinates == null)
            {
                return false;
            }
            if (maxCoordinates.Length == 2)
            {
                foreach (var maxCoordinate in maxCoordinates)
                {
                    if (!int.TryParse(maxCoordinate, out var result))
                    {
                        ConsoleHelper.WriteErrorMessage(errMessage);
                        return false;
                    }
                }
                return true;
            }
            ConsoleHelper.WriteErrorMessage(errMessage);
            return false;
        }
    }
}
