using IReckonUAssignment.Logic.ApiModels;
using System.Collections.Generic;
using System.IO;

namespace IReckonUAssignment.Logic.ProductFileParsing
{
    internal interface IProductCSVFileParser
    {
        IEnumerable<ApiProduct> ParseProductFile(Stream productFile);
    }
}