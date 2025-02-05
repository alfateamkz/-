using Alfateam.Marketing.Models.SalesGenerators.StartOptions.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions.Items
{
    public class StartEveryDayDayOfWeekItemDTO : DTOModelAbs<StartEveryDayDayOfWeekItem>
    {
        public DayOfWeek DayOfWeek { get; set; }
    }
}
