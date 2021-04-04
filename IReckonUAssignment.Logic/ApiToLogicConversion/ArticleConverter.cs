using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Logic.Extensions;
using IReckonUAssignment.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IReckonUAssignment.Logic.ApiToLogicConversion
{
    internal class ArticleConverter : IArticleConverter
    {
        private readonly ILogger<ArticleConverter> logger;

        public ArticleConverter(ILogger<ArticleConverter> logger)
        {
            this.logger = logger;
        }

        public bool TryConvertArticle(ApiProduct apiProduct, out Article article)
        {
            List<string>  errors = new List<string>();

            if(string.IsNullOrEmpty(apiProduct.ArticleCode))
            {
                errors.Add($"{nameof(apiProduct.ArticleCode)} cannot be null or empty");
            }

            if (apiProduct.ArticleCode != null
                && apiProduct.ArticleCode.Length > 50)
            {
                errors.Add($"{nameof(apiProduct.ArticleCode)} cannot be more than 50 chracters");
            }

            if(errors.Any())
            {
                LogErrors(apiProduct, errors);
                article = null;
                return false;
            }

            article = new Article(
                Code: apiProduct.ArticleCode,
                ColorCode: apiProduct.ColorCode,
                Description: apiProduct.Description,
                Q1: apiProduct.Q1
            );

            return true;
        }

        private void LogErrors(ApiProduct apiProduct, List<string> errors)
        {
            //TODO: Move error logging formatting  to dedicated class
            logger.LogWarning($"Could not create Article from apiProduct: {Environment.NewLine}{apiProduct}{Environment.NewLine}{errors.ToMultilineString()}");
        }
    }
}