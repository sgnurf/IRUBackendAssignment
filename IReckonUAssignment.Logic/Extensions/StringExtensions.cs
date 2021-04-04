using System;
using System.Collections.Generic;
using System.Linq;

namespace IReckonUAssignment.Logic.Extensions
{
    public static class StringExtensions
    {
        public static int? ParseIntOrDefault(this string input)
        {
            return int.TryParse(input, out int result)
                ? result
                : null;
        }

        public static string ToMultilineString(this IEnumerable<string> input)
        {
            return input.Aggregate((currentValue, newValue)
                => currentValue + Environment.NewLine + newValue);
        }
    }
}