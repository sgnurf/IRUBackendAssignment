using IReckonUAssignment.Logic.ApiModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace IReckonUAssignment.Logic.ProductFileParsing
{
    internal class ProductCSVFileParser : IProductCSVFileParser
    {
        private const char fieldDelimiterCharacter = ',';
        private const int expectedFieldCount = 10;
        private readonly ILogger<ProductCSVFileParser> logger;

        public ProductCSVFileParser(ILogger<ProductCSVFileParser> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<ApiProduct> ParseProductFile(Stream productFile)
        {
            using (StreamReader reader = new StreamReader(productFile))
            {
                IgnoreHeaderLine(reader);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineValues = line.Split(fieldDelimiterCharacter);
                    if (lineValues.Length != expectedFieldCount)
                    {
                        LogLineError(line);
                        continue;
                    }

                    yield return new ApiProduct(lineValues);
                }
            }
        }

        private void LogLineError(string line)
        {
            logger.LogInformation($"Ignoring malformed entry: {Environment.NewLine}{line}");
        }

        private static void IgnoreHeaderLine(StreamReader reader)
        {
            reader.ReadLine();
        }
    }
}