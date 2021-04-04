using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Models;
using System.Collections.Generic;

namespace IReckonUAssignment.Logic.ApiToLogicConversion
{
    internal interface IProductConverter
    {
        bool TryConvertProduct(ApiProduct apiProduct, out Product product);
    }
}