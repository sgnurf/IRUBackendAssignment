using IReckonUAssignment.DAL;
using IReckonUAssignment.EntityFrameworkDAL.Repositories;
using IReckonUAssignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IReckonUAssignment.EntityFrameworkDAL.Services
{
    internal class EntityFrameworkArticleStore : IArticleStore
    {
        private readonly IArticleRepository articleRepository;

        public EntityFrameworkArticleStore(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task StoreAsync(IEnumerable<Article> articles)
        {
            await articleRepository.BulkInsertAsync(articles);
        }
    }
}