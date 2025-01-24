using Alfateam.AdminPanelGeneral.API.Abstractions;

namespace Alfateam.AdminPanelGeneral.API.Models.Filters.Stats
{
    public class WebsiteVisitsSearchFilter : SearchFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
