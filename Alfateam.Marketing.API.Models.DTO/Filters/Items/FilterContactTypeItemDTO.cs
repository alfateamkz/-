using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Filters.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters.Items
{
    public class FilterContactTypeItemDTO : DTOModelAbs<FilterContactTypeItem>
    {
        public ContactType Type { get; set; }
    }
}
