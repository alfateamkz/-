using Alfateam.SharedModels.Abstractions;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Enums;

namespace Alfateam.Telephony.API.Models.SearchFilters.Numbers
{
    public class NumberSMSSearchFilter : SearchFilter
    {
        public int NumberId { get; set; }


        public NumberSMSType? SMSType { get; set; }
        public string? Phone { get; set; }
        public DateFilterModel? ReceivedOrSentAtDateFilter { get; set; }

    }
}
