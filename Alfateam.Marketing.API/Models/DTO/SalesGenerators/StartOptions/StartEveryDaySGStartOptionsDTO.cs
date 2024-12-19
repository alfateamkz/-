using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions.Items;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions;
using Alfateam.Marketing.Models.SalesGenerators.StartOptions.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.SalesGenerators.StartOptions
{
    public class StartEveryDaySGStartOptionsDTO : SalesGeneratorStartOptionsDTO
    {
        public TimeOnly Time { get; set; }


        public List<StartEveryDayDayItemDTO> Days { get; set; } = new List<StartEveryDayDayItemDTO>();
        public List<StartEveryDayDayOfWeekItemDTO> DaysOfWeek { get; set; } = new List<StartEveryDayDayOfWeekItemDTO>();
        public List<StartEveryDayMonthItemDTO> Months { get; set; } = new List<StartEveryDayMonthItemDTO>();
    }
}
