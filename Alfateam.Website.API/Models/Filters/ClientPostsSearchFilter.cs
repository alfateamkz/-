namespace Alfateam.Website.API.Models.Filters
{
    public class ClientPostsSearchFilter
    {
        public int Offset { get; set; }
        public int Count { get; set; } = 20;



        public int CategoryId { get; set; }
        public int IndustryId { get; set; }
        public string Query { get; set; }


    }
}
