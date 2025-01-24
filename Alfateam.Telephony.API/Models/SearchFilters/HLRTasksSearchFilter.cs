using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.Models.Enums;

namespace Alfateam.Telephony.API.Models.SearchFilters
{
    public class HLRTasksSearchFilter : SearchFilter
    {
        public HLRTaskStatus? Status { get; set; }
    }
}
