using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions.Items;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions.Items;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions
{
    public class StartEveryDaySGStartOptionsDTO : c
    {
        public TimeOnly Time { get; set; }


        public List<StartEveryDayDayItemDTO> Days { get; set; } = new List<StartEveryDayDayItemDTO>();
        public List<StartEveryDayDayOfWeekItemDTO> DaysOfWeek { get; set; } = new List<StartEveryDayDayOfWeekItemDTO>();
        public List<StartEveryDayMonthItemDTO> Months { get; set; } = new List<StartEveryDayMonthItemDTO>();
    }
}
