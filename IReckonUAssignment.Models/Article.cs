using System.Collections.Generic;

namespace IReckonUAssignment.Models
{
    public record Article(string Code, string ColorCode, string Description, string Q1) {

        public List<Product> Products { get; } = new List<Product>();

    }
}