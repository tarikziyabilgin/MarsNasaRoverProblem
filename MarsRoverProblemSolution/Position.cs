using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace MarsRoverProblemSolution
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MarsRoverProblemSolution.Directions Direction { get; set; }

        public Position()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

        public string[] ReadPositionForRover(int[] maxCoordinates)
        {
            string[] startPosition = null;
            while (!ValidatePosition(startPosition, maxCoordinates))
            {
                Console.WriteLine("Please Enter Rover's Initial Position:");
                startPosition = Console.ReadLine()?.Trim().Split(' ');
            }
            return startPosition;
        }
        public bool ValidatePosition(string[] positions, int[] maxCoordinates)
        {
            if (positions == null)
            {
                return false;
            }
            int flag = 0;
            try
            {
                if (Convert.ToInt32(positions[0]) >= 0 && Convert.ToInt32(positions[0]) <= maxCoordinates[0])
                {
                    flag++;
                }
                else
                {
                    ConsoleHelper.WriteErrorMessage($"Please Enter Valid Start X Coordinate. It must be less than or equal to {maxCoordinates[0]}");
                }
                if (Convert.ToInt32(positions[1]) >= 0 && Convert.ToInt32(positions[1]) <= maxCoordinates[1])
                {
                    flag++;
                }
                else
                {
                    ConsoleHelper.WriteErrorMessage($"Please Enter Valid Start Y Coordinate. It must be less than or equal to {maxCoordinates[1]}");
                }
                if (Enum.IsDefined(typeof(MarsRoverProblemSolution.Directions), positions[2]))
                {
                    flag++;
                }
                else
                {
                    ConsoleHelper.WriteErrorMessage($"Please Enter Valid Start Directions. It must be one of the following options:{MarsRoverProblemSolution.Directions.E.GetAllNamesWithCommaSeperated()}");
                }
            }
            catch (Exception e)
            {
                ConsoleHelper.WriteErrorMessage($"Please Enter Valid Coordinates And Directions. Error Message: {e.Message}");
                return false;
            }
            return flag == 3;
        }



        public string ReadInstructionsForRover()
        {
            string instructions = null;
            while (!ValidateInstructions(instructions))
            {
                Console.WriteLine("Please Enter instructions for Rover.");
                instructions = Console.ReadLine().ToUpper();
            }
            // return maxCoordinates.Select(m => Convert.ToInt32(m)).ToArray();
            return instructions;
        }

        private bool ValidateInstructions(string instructions)
        {
            if (instructions == null)
            {
                return false;
            }
            foreach (var instruction in instructions)
            {
                if (!(instruction == 'M' || instruction == 'L' || instruction == 'R'))
                {
                    ConsoleHelper.WriteErrorMessage($"Wrong instruction {instruction}. It can be only L, R or M");
                    return false;
                }
            }
            return true;
        }

        public void SetStartPositions(string[] startPosition)
        {
            this.X = Convert.ToInt32(startPosition[0]);
            this.Y = Convert.ToInt32(startPosition[1]);
            Enum.TryParse(startPosition[2], out Directions direction);
            this.Direction = direction;
        }

        public void StartRover(int[] maxCoordinates)
        {
            string[] startPosition = ReadPositionForRover(maxCoordinates);
            string instructions = ReadInstructionsForRover();
            SetStartPositions(startPosition);
            PlayRover(maxCoordinates, instructions);
        }

        public void PlayRover(int[] maxCoordinates, string instructions)
        {
            foreach (var move in instructions)
            {
                switch (move)
                {
                    case (char)InstructionsEnum.MoveForward:
                        this.MoveForward();
                        break;
                    case (char)InstructionsEnum.Left:
                        this.RotateLeft();
                        break;
                    case (char)InstructionsEnum.Right:
                        this.RotateRight();
                        break;
                    default:
                        ConsoleHelper.WriteErrorMessage($"Invalid Instruction {move}");
                        break;
                }

                if (this.X < 0 || this.X > maxCoordinates[0] || this.Y < 0 || this.Y > maxCoordinates[1])
                {
                    throw new Exception($"Position cannot be beyond boundaries (0 , 0) and ({maxCoordinates[0]} , {maxCoordinates[1]})");
                }
            }
        }

        private void MoveForward()
        {
            switch (this.Direction)
            {
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                default:
                    break;
            }
        }
        private void RotateLeft()
        {
            switch (this.Direction)
            {
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                default:
                    break;
            }
        }

        private void RotateRight()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

    }

    public interface IPosition
    {
        void SetStartPositions(string[] startPosition);
        void StartRover(int[] maxCoordinates);
        string[] ReadPositionForRover(int[] maxCoordinates);
        string ReadInstructionsForRover();
    }
}
