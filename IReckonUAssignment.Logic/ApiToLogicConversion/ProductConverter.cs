using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Logic.Extensions;
using IReckonUAssignment.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IReckonUAssignment.Logic.ApiToLogicConversion
{
    internal class ProductConverter : IProductConverter
    {
        private readonly ILogger<ProductConverter> logger;

        public ProductConverter(ILogger<ProductConverter> logger)
        {
            this.logger = logger;
        }

        public bool TryConvertProduct(ApiProduct apiProduct, out Product product)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(apiProduct.Key))
            {
                errors.Add($"{nameof(apiProduct.Key)} cannot be null or empty");
            }

            if (apiProduct.Key != null 
                && apiProduct.Key.Length > 50)
            {
                errors.Add($"{nameof(apiProduct.Key)} cannot be more than 50 chracters");
            }

            if (!int.TryParse(apiProduct.Price, out int price))
            {
                errors.Add($"{nameof(apiProduct.Price)} has to be an integer");
            }

            if (errors.Any())
            {
                LogErrors(apiProduct, errors);
                product = null;
                return false;
            }

            product = new Product(
                Key: apiProduct.Key,
                ArticleCode: apiProduct.ArticleCode,
                Price: price,
                DiscountPrice: apiProduct.DiscountPrice.ParseIntOrDefault(),
                DeliveredIn: apiProduct.DeliveredIn,
                Size: apiProduct.Size.ParseIntOrDefault(),
                Color: apiProduct.Color
            );

            return true;
        }

        private void LogErrors(ApiProduct apiProduct, List<string> errors)
        {
            //TODO: Move error logging formatting  to dedicated class
            logger.LogWarning($"Could not create Product from apiProduct: {Environment.NewLine}{apiProduct}{Environment.NewLine}{errors.ToMultilineString()}");
        }
    }
}