using System;
using System.ComponentModel;

namespace MarsRoverProblemSolution
{
    public static class EnumUtils
    {
        public static string GetAllNamesWithCommaSeperated(this Directions directions)
        {
            var result = "";
            foreach (var value in Enum.GetNames(typeof(Directions)))
            {
                if (result.Equals(string.Empty))
                {
                    result = value;
                }
                else
                {
                    result = result + ", " + value;
                }
            }
            return result;
        }

        public static string GetDescription(this InstructionsEnum instructions)
        {
            var type = instructions.GetType();
            var memInfo = type.GetMember(instructions.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(InstructionsEnum), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }

    }
}