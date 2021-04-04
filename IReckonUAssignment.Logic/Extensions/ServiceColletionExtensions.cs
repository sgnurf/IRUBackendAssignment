using IReckonUAssignment.Logic.ApiToLogicConversion;
using IReckonUAssignment.Logic.ProductFileParsing;
using Microsoft.Extensions.DependencyInjection;

namespace IReckonUAssignment.Logic.Extensions
{
    public static class ServiceColletionExtensions
    {
        public static void AddLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IProductCSVFileParser, ProductCSVFileParser>();
            serviceCollection.AddSingleton<IApiToLogicConverter, ApiToLogicConverter>();
            serviceCollection.AddSingleton<IArticleConverter, ArticleConverter>();
            serviceCollection.AddSingleton<IProductConverter, ProductConverter>();
            serviceCollection.AddScoped<IProductFileProcessor, ProductFileProcessor>();
        }
    }
}