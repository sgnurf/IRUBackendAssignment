using IReckonUAssignment.EntityFrameworkDAL.Entities;
using IReckonUAssignment.Models;
using System.Linq;

namespace IReckonUAssignment.EntityFrameworkDAL.Services
{
    internal class ArticleEntityMapper : IArticleEntityMapper
    {
        private readonly IProductEntityMapper productEntityMapper;

        public ArticleEntityMapper(IProductEntityMapper productEntityMapper)
        {
            this.productEntityMapper = productEntityMapper;
        }

        public ArticleEntity Map(Article article)
        {
            ArticleEntity articleEntity = new ArticleEntity
            {
                Code = article.Code,
                ColorCode = article.ColorCode,
                Description = article.Description,
                Q1 = article.Q1
            };

            articleEntity.Products.AddRange(article.Products.Select(p => productEntityMapper.Map(p)));

            return articleEntity;
        }
    }
}