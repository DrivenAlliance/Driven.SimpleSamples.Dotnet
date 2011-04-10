using ExcelDna.Integration;

namespace Driven.ExcelFunctionLibrary
{
    public class SimpleFunction
    {
        [ExcelFunction(Description = "Another adding function.", Category = "FR - Debug")]
        public static double aaaAddTwo(
            [ExcelArgument(Description = "The first value", Name = "First Arg")]double a,
            [ExcelArgument(Description = "The second value", Name = "Second Arg")]double b)
        {
            return a + b;
        }
    }
}