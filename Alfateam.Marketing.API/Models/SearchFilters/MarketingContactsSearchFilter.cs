using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.Models.Enums;

namespace Alfateam.Marketing.API.Models.SearchFilters
{
    public class MarketingContactsSearchFilter : SearchFilter
    {
        public ContactType? ContactType { get; set; }
        public bool? FromAlfateamSalesCRM { get; set; }
    }
}
