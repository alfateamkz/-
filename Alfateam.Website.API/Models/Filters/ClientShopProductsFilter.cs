namespace Alfateam.Website.API.Models.Filters
{
    public class ClientShopProductsFilter
    {
        public int CategoryId { get; set; }
        public string Query { get; set; }



        public int Offset { get; set; }
        public int Count { get; set; } = 20;
    }
}
