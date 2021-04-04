using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IReckonUAssignment.EntityFrameworkDAL.Entities
{
    internal class ProductEntity
    {
        [Key]
        [Column(TypeName = "varchar(200)")]
        public string Key { get; set; }

        public int Price { get; set; }

        public int? DiscountPrice { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string DeliveredIn { get; set; }

        public int? Size { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Color { get; set; }

        public string ArticleCode { get; set; }

        public ArticleEntity Article { get; set; }
    }
}