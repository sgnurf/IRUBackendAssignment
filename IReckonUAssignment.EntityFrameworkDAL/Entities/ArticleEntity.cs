using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IReckonUAssignment.EntityFrameworkDAL.Entities
{
    internal class ArticleEntity
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ColorCode { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Q1 { get; set; }

        public List<ProductEntity> Products { get; } = new List<ProductEntity>();
    }
}