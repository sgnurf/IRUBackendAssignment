namespace IReckonUAssignment.Models
{
    public record Product(string Key, string ArticleCode, int Price, int? DiscountPrice, string DeliveredIn, int? Size, string Color);
}