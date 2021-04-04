using EFCore.BulkExtensions;
using IReckonUAssignment.EntityFrameworkDAL.DBContext;
using IReckonUAssignment.EntityFrameworkDAL.Services;
using IReckonUAssignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IReckonUAssignment.EntityFrameworkDAL.Repositories
{
    internal class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IArticleEntityMapper articleEntityMapper;

        public ArticleRepository(ApplicationDbContext applicationDbContext, IArticleEntityMapper articleEntityMapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.articleEntityMapper = articleEntityMapper;
        }

        public async Task BulkInsertAsync(IEnumerable<Article> articles)
        {
            await applicationDbContext.BulkInsertOrUpdateAsync(
                articles.Select(a => articleEntityMapper.Map(a))
                .ToList()
            , b => b.IncludeGraph = true);
        }
    }
}