using CommandDotNet;
using System.Collections.Generic;
using System.IO;

namespace IReckonUAssignment.CsvFileGenerator
{
    internal class CSVFileGenerator
    {
        private const string headerLine = "Key,ArtikelCode,ColorCode,Description,Price,DiscountPrice,DeliveredIn,Q1,Size,Color";
        private const string linePattern = "p{0},a{1},Color{1},Product and Article Description: {0}-{1},10,0,DeliveredIn,Q1,10,Color{0}";

        [DefaultMethod]
        public void GenerateCSVFile(string file, int articleCount, int productCount)
        {
            IEnumerable<string> lines = GenerateLines(articleCount, productCount);

            File.WriteAllLines(file, lines);
        }

        private IEnumerable<string> GenerateLines(int articleCount, int productCount)
        {
            yield return headerLine;

            for (int i = 0; i < articleCount; ++i)
            {
                for (int j = 0; j < productCount; ++j)
                {
                    yield return string.Format(linePattern, j, i);
                }
            }
        }
    }
}