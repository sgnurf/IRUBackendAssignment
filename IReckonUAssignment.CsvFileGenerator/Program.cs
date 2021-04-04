using CommandDotNet;

namespace IReckonUAssignment.CsvFileGenerator
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            return new AppRunner<CSVFileGenerator>()
                .UseDefaultMiddleware()
                .Run(args);
        }
    }
}