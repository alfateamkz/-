using Alfateam.Telephony.API.Abstractions;

namespace Alfateam.Telephony.API.Models.SearchFilters
{
    public class ContactsSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }
    }
}
