using Alfateam.Telephony.API.Abstractions;

namespace Alfateam.Telephony.API.Models.SearchFilters
{
    public class HLRTaskResultsSearchFilter : SearchFilter
    {
        public int TaskId { get; set; }

        public int? IterationId { get; set; }
        public bool? IsActive { get; set; }


        public string? Status { get; set; }
        public string? MCC { get; set; }
        public string? MNC { get; set; }
        public string? OriginalNetworkName { get; set; }
        public string? ErrorDescription { get; set; }
    }
}
