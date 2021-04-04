using IReckonUAssignment.DAL;
using IReckonUAssignment.Logic.ApiModels;
using IReckonUAssignment.Logic.ApiToLogicConversion;
using IReckonUAssignment.Logic.ProductFileParsing;
using IReckonUAssignment.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IReckonUAssignment.Logic
{
    internal class ProductFileProcessor : IProductFileProcessor
    {
        private readonly IProductCSVFileParser productCSVFileParser;
        private readonly IApiToLogicConverter apiToLogicConverter;
        private readonly IEnumerable<IArticleStore> articleStores;

        public ProductFileProcessor(
            IProductCSVFileParser productCSVFileParser,
            IApiToLogicConverter apiToLogicConverter,
            IEnumerable<IArticleStore> articleStores)
        {
            this.productCSVFileParser = productCSVFileParser;
            this.apiToLogicConverter = apiToLogicConverter;
            this.articleStores = articleStores;
        }

        public async Task ProcessProductFile(Stream productFile)
        {
            IEnumerable<ApiProduct> apiProducts = productCSVFileParser.ParseProductFile(productFile);

            IEnumerable<Article> articles = apiToLogicConverter.Convert(apiProducts);

            foreach (IArticleStore store in articleStores)
            {
                await store.StoreAsync(articles);
            }
        }
    }
}