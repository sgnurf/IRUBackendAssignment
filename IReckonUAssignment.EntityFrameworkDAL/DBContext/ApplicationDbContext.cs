using IReckonUAssignment.EntityFrameworkDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IReckonUAssignment.EntityFrameworkDAL.DBContext
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<ArticleEntity> Articles { get; set; }
    }
}