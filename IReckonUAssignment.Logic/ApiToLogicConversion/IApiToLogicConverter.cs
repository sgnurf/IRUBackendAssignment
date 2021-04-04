using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Models;
using System.Collections.Generic;

namespace IReckonUAssignment.Logic.ApiToLogicConversion
{
    internal interface IApiToLogicConverter
    {
        IEnumerable<Article> Convert(IEnumerable<ApiProduct> apiProducts);
    }
}