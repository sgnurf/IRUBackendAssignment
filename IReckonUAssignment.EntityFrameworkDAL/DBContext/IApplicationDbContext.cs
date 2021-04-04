using IReckonUAssignment.EntityFrameworkDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IReckonUAssignment.EntityFrameworkDAL.DBContext
{
    internal interface IApplicationDbContext
    {
        DbSet<ArticleEntity> Articles { get; set; }
        DbSet<ProductEntity> Products { get; set; }
    }
}