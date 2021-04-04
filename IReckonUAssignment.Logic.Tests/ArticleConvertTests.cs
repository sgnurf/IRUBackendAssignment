using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Logic.ApiToLogicConversion;
using IReckonUAssignment.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace IReckonUAssignment.Logic.Tests
{
    public class ArticleConvertTests
    {
        [Fact]
        public void TryConvertArticle_ArticleIsValid_ArticleReturned()
        {
            ApiProduct apiProduct = CreateMockApiProduct();
            Mock<ILogger<ArticleConverter>> logger = new Mock<ILogger<ArticleConverter>>();
            ArticleConverter articleConverter = new ArticleConverter(logger.Object);

            bool result = articleConverter.TryConvertArticle(apiProduct, out Article article);

            Assert.True(result);
            Assert.Equal(apiProduct.ArticleCode, article.Code);
            Assert.Equal(apiProduct.ColorCode, article.ColorCode);
            Assert.Equal(apiProduct.Description, article.Description);
            Assert.Equal(apiProduct.Q1, article.Q1);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TryConvertArticle_ArticleCodeIsInvalid_ErrorReturned(string articleCode)
        {
            ApiProduct apiProduct = CreateMockApiProduct(articleCode: articleCode);
            Mock<ILogger<ArticleConverter>> logger = new Mock<ILogger<ArticleConverter>>();
            ArticleConverter articleConverter = new ArticleConverter(logger.Object);

            bool result = articleConverter.TryConvertArticle(apiProduct, out Article article);

            Assert.False(result);
            Assert.Null(article);
        }

        [Fact]
        public void TryConvertArticle_ArticleCodeIsTooLong_ErrorReturned()
        {
            string articleCode51Characters = new String('0', 51);
            ApiProduct apiProduct = CreateMockApiProduct(articleCode: articleCode51Characters);
            Mock<ILogger<ArticleConverter>> logger = new Mock<ILogger<ArticleConverter>>();
            ArticleConverter articleConverter = new ArticleConverter(logger.Object);

            bool result = articleConverter.TryConvertArticle(apiProduct, out Article article);

            Assert.False(result);
            Assert.Null(article);
        }

        private static ApiProduct CreateMockApiProduct(string articleCode = "code")
            => new ApiProduct("productKey", articleCode, "colorCode", "Description", "price", "DiscountPrice", "DeliveredIn", "Q1", "Size", "color");
    }
}