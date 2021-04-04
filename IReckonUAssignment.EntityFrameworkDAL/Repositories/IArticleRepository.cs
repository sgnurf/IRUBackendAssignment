using IReckonUAssignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IReckonUAssignment.EntityFrameworkDAL.Repositories
{
    internal interface IArticleRepository
    {
        Task BulkInsertAsync(IEnumerable<Article> articles);
    }
}