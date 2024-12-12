using Alfateam.Marketing.Models.Filters;
using Alfateam.Marketing.Models;
using Alfateam.Marketing.Models.Segments;
using Alfateam.Website.API.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Filters;

namespace Alfateam.Marketing.API.Models.DTO.Segments
{
    public class SegmentDTO : DTOModelAbs<Segment>
    {
        public string Title { get; set; }
        public CustomersFilterDTO CustomersFilter { get; set; }
        public LeadsFilterDTO LeadsFilter { get; set; }



        public List<MarketingContactDTO> OtherContacts { get; set; } = new List<MarketingContactDTO>();
    }
}
