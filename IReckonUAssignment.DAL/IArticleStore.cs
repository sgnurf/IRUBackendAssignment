using IReckonUAssignment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IReckonUAssignment.DAL
{
    public interface IArticleStore
    {
        Task StoreAsync(IEnumerable<Article> articles);
    }
}