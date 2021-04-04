using IReckonUAssignment.DAL;
using IReckonUAssignment.JSonDAL.Configuration;
using IReckonUAssignment.JSonDAL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Storage.Net;
using Storage.Net.Blobs;

namespace IReckonUAssignment.JSonDAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJsonDALServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JSonDALConfiguration>(configuration.GetSection("JSonDAL"));
        }

        public static void AddJsonDALServices(this IServiceCollection services)
        {
            services.AddTransient<IArticleStore, JSonArticleStore>();
            services.AddTransient<IBlobStorage>(sp =>
            {
                var configuration = sp.GetRequiredService<IOptions<JSonDALConfiguration>>();
                return StorageFactory.Blobs.FromConnectionString(configuration.Value.StorageConnectionString);
            });
        }
    }
}