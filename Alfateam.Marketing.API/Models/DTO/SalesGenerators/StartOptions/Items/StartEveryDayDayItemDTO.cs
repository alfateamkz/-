using Alfateam.Marketing.Models.SalesGenerators.StartOptions.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions.Items
{
    public class StartEveryDayDayItemDTO : DTOModelAbs<StartEveryDayDayItem>
    {
        public int Day { get; set; }
    }
}
