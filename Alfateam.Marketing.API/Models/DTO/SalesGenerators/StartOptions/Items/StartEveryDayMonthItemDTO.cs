using Alfateam.Marketing.Models.SalesGenerators.StartOptions.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions.Items
{
    public class StartEveryDayMonthItemDTO : DTOModelAbs<StartEveryDayMonthItem>
    {
        public int Month { get; set; }
    }
}
