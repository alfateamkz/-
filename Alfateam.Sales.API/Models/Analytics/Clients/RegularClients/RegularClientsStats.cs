namespace Alfateam.Sales.API.Models.Analytics.Clients.RegularClients
{
    public class RegularClientsStats
    {
        public List<RegularClientsStatsRatingItem> ByRating { get; set; } = new List<RegularClientsStatsRatingItem>();
    }
}
