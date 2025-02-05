using Alfateam.Telephony.Models.Contacts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Contacts
{
    public class ContactCategoryDTO : DTOModelAbs<ContactCategory>
    {
        public string Title { get; set; }
    }
}
