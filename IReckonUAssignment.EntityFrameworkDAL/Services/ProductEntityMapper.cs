using IReckonUAssignment.EntityFrameworkDAL.Entities;
using IReckonUAssignment.Models;

namespace IReckonUAssignment.EntityFrameworkDAL.Services
{
    internal class ProductEntityMapper : IProductEntityMapper
    {
        public ProductEntity Map(Product product)
        {
            return new ProductEntity
            {
                ArticleCode = product.ArticleCode,
                Color = product.Color,
                DeliveredIn = product.DeliveredIn,
                DiscountPrice = product.DiscountPrice,
                Key = product.Key,
                Price = product.Price,
                Size = product.Size
            };
        }
    }
}