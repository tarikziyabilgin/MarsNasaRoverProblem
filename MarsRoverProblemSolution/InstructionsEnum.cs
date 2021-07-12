using System.ComponentModel;

namespace MarsRoverProblemSolution
{
    public enum InstructionsEnum
    {
        [Description("R")]
        Right='R',
        [Description("L")]
        Left='L',
        [Description("M")]
        MoveForward='M'
    }
}