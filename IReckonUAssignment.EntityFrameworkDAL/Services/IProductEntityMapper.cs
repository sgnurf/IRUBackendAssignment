using IReckonUAssignment.EntityFrameworkDAL.Entities;
using IReckonUAssignment.Models;

namespace IReckonUAssignment.EntityFrameworkDAL.Services
{
    internal interface IProductEntityMapper
    {
        ProductEntity Map(Product product);
    }
}