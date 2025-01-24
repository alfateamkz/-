using Alfateam.SharedModels.Abstractions;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Enums;
using Alfateam.Telephony.Models.Enums;

namespace Alfateam.Telephony.API.Models.SearchFilters.Numbers
{
    public class NumberCallsSearchFilter : SearchFilter
    {
        public int NumberId { get; set; }


        public NumberCallType? CallType { get; set; }
        public DateFilterModel? CallCreatedAtDateFilter { get; set; }
        public DateFilterModel? CallStartedAtDateFilter { get; set; }
        public DateFilterModel? CallEndedAtDateFilter { get; set; }



        public CallStatus? Status { get; set; }



        public bool? HasRecord { get; set; }
        public string? Comment { get; set; }
    }
}
