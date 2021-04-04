using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace IReckonUAssignment.Logic.ApiToLogicConversion
{
    internal class ApiToLogicConverter : IApiToLogicConverter
    {
        private readonly IProductConverter productFactory;
        private readonly IArticleConverter articleFactory;

        public ApiToLogicConverter(IProductConverter productFactory, IArticleConverter articleFactory)
        {
            this.productFactory = productFactory;
            this.articleFactory = articleFactory;
        }

        public IEnumerable<Article> Convert(IEnumerable<ApiProduct> apiProducts)
        {
            Dictionary<string, Article> articles = new Dictionary<string, Article>();

            foreach (ApiProduct apiProduct in apiProducts)
            {
                if (
                    TryCreateOrGetArticle(articles, apiProduct, out Article article)
                        && productFactory.TryConvertProduct(apiProduct, out Product product)
                )
                {
                    article.Products.Add(product);
                    articles[article.Code] = article;
                }
            }

            return articles.Values;
        }

        private bool TryCreateOrGetArticle(Dictionary<string, Article> articles, ApiProduct apiProduct, out Article article)
        {
            if (articles.TryGetValue(apiProduct.ArticleCode, out article))
            {
                return true;
            }

            return articleFactory.TryConvertArticle(apiProduct, out article);
        }
    }
}