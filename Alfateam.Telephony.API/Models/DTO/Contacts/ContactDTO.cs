using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.Contacts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Contacts
{
    public class ContactDTO : DTOModelAbs<Contact>
    {
        public string? Title { get; set; }
        public string Phone { get; set; }



        [ForClientOnly]
        public ContactCategoryDTO Category { get; set; }

        [HiddenFromClient]
        public int CategoryId { get; set; }
    }
}
