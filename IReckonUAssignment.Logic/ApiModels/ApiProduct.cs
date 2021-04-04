namespace IReckonUAssignment.Logic.ApiModels
{
    internal record ApiProduct(
        string Key,
        string ArticleCode,
        string ColorCode,
        string Description,
        string Price,
        string DiscountPrice,
        string DeliveredIn,
        string Q1,
        string Size,
        string Color)
    {
        public ApiProduct(string[] lineValues)
            : this(lineValues[0], lineValues[1], lineValues[2], lineValues[3], lineValues[4], lineValues[5], lineValues[6], lineValues[7], lineValues[8], lineValues[9])
        {
        }
    }
}