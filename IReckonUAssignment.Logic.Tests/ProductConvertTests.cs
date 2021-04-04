using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Logic.ApiToLogicConversion;
using IReckonUAssignment.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace IReckonUAssignment.Logic.Tests
{
    public class ProductConvertTests
    {
        [Fact]
        public void TryConvertProduct_ProductIsValid_ProductReturned()
        {
            ApiProduct apiProduct = CreateMockApiProduct();
            Mock<ILogger<ProductConverter>> logger = new Mock<ILogger<ProductConverter>>();
            ProductConverter productConverter = new ProductConverter(logger.Object);

            bool result = productConverter.TryConvertProduct(apiProduct, out Product product);

            Assert.True(result);
            Assert.Equal(apiProduct.Key, product.Key);
            Assert.Equal(apiProduct.ArticleCode, product.ArticleCode);
            Assert.Equal(apiProduct.Color, product.Color);
            Assert.Equal(apiProduct.DeliveredIn, product.DeliveredIn);
            Assert.Equal(10, product.DiscountPrice);
            Assert.Equal(20, product.Price);
            Assert.Equal(30, product.Size);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TryConvertArticle_ArticleCodeIsInvalid_ErrorReturned(string productKey)
        {
            ApiProduct apiProduct = CreateMockApiProduct(productKey: productKey);
            Mock<ILogger<ProductConverter>> logger = new Mock<ILogger<ProductConverter>>();
            ProductConverter productConverter = new ProductConverter(logger.Object);

            bool result = productConverter.TryConvertProduct(apiProduct, out Product product);
            Assert.False(result);
            Assert.Null(product);
        }

        [Fact]
        public void TryConvertArticle_ArticleCodeIsTooLong_ErrorReturned()
        {
            string productKey51Characters = new string('0', 51);
            ApiProduct apiProduct = CreateMockApiProduct(productKey: productKey51Characters);
            Mock<ILogger<ProductConverter>> logger = new Mock<ILogger<ProductConverter>>();
            ProductConverter productConverter = new ProductConverter(logger.Object);

            bool result = productConverter.TryConvertProduct(apiProduct, out Product product);

            Assert.False(result);
            Assert.Null(product);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("string")]
        [InlineData("123abc")]
        [InlineData("12.34")]
        public void TryConvertArticle_PriceIsNotInteger_ErrorReturned(string price)
        {
            ApiProduct apiProduct = CreateMockApiProduct(price: price);
            Mock<ILogger<ProductConverter>> logger = new Mock<ILogger<ProductConverter>>();
            ProductConverter productConverter = new ProductConverter(logger.Object);

            bool result = productConverter.TryConvertProduct(apiProduct, out Product product);

            Assert.False(result);
            Assert.Null(product);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("string")]
        [InlineData("123abc")]
        [InlineData("12.34")]
        public void TryConvertArticle_DiscountPriceIsNotInteger_ProductReturnedWithNullDiscountPrice(string price)
        {
            ApiProduct apiProduct = CreateMockApiProduct(discountPrice: price);
            Mock<ILogger<ProductConverter>> logger = new Mock<ILogger<ProductConverter>>();
            ProductConverter productConverter = new ProductConverter(logger.Object);

            bool result = productConverter.TryConvertProduct(apiProduct, out Product product);

            Assert.True(result);
            Assert.Null(product.DiscountPrice);
        }

        private static ApiProduct CreateMockApiProduct(string productKey = "key", string price = "20", string discountPrice = "10")
            => new ApiProduct(productKey, "articleCode", "colorCode", "Description", price, discountPrice, "DeliveredIn", "Q1", "30", "color");
    }
}