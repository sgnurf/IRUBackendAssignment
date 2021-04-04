using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Models;
using System.Collections.Generic;

namespace IReckonUAssignment.Logic.ApiToLogicConversion
{
    internal interface IArticleConverter
    {
        bool TryConvertArticle(ApiProduct apiProduct, out Article article);
    }
}