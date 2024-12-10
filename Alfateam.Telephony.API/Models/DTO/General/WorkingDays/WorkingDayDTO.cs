using Alfateam.Telephony.Models.General.WorkingDays;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General.WorkingDays
{
    public class WorkingDayDTO : DTOModelAbs<WorkingDay>
    {
        public DayOfWeek DayOfWeek { get; set; }
        public bool IsWorkingDay { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
    }
}
