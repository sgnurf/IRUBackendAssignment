using IReckonUAssignment.EntityFrameworkDAL.Entities;
using IReckonUAssignment.Models;

namespace IReckonUAssignment.EntityFrameworkDAL.Services
{
    internal interface IArticleEntityMapper
    {
        ArticleEntity Map(Article article);
    }
}