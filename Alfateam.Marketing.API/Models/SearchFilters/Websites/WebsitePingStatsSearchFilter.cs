using Alfateam.Marketing.API.Abstractions;
using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Filters.Dates.Props;

namespace Alfateam.Marketing.API.Models.SearchFilters.Websites
{
    public class WebsitePingStatsSearchFilter : SearchFilter
    {
        public int WebsiteId { get; set; }

        public DateFilterModel Period { get; set; }
    }
}
