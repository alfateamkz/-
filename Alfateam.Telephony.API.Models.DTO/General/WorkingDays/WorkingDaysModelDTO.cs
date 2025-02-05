using Alfateam.Telephony.Models.General.WorkingDays;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General.WorkingDays
{
    public class WorkingDaysModelDTO : DTOModelAbs<WorkingDaysModel>
    {
        
        public List<WorkingDayDTO> Days { get; set; } = new List<WorkingDayDTO>();
    }
}
