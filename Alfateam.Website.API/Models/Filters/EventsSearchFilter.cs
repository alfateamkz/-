namespace Alfateam.Website.API.Models.Filters
{
    public class EventsSearchFilter
    {
        public int Offset { get; set; }
        public int Count { get; set; } = 20;



        public int CategoryId { get; set; }
        public int FormatId { get; set; }
        public string Query { get; set; }


    }
}
