using IReckonUAssignment.DAL;
using IReckonUAssignment.EntityFrameworkDAL.Configuration;
using IReckonUAssignment.EntityFrameworkDAL.DBContext;
using IReckonUAssignment.EntityFrameworkDAL.Repositories;
using IReckonUAssignment.EntityFrameworkDAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IReckonUAssignment.EntityFrameworkDAL.Extensions
{
    public static class ServiceColletionExtensions
    {
        public static void AddEntityFrameworkDALServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EntityFrameworkDALConfiguration>(configuration.GetSection("EntityFrameworkDAL"));
        }

        public static void AddEntityFrameworkDALServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IArticleRepository, ArticleRepository>();
            serviceCollection.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                string connectionString = sp.GetRequiredService<IOptions<EntityFrameworkDALConfiguration>>().Value.ConnectionString;
                options.UseSqlServer(connectionString);
            });
            serviceCollection.AddSingleton<IArticleEntityMapper, ArticleEntityMapper>();
            serviceCollection.AddSingleton<IProductEntityMapper, ProductEntityMapper>();
            serviceCollection.AddTransient<IArticleStore, EntityFrameworkArticleStore>();
        }
    }
}