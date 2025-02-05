using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;

namespace Alfateam.Website.API.Models.DTO.Forms
{
    public class ContactMeFormDTO : SentFromWebsiteFormDTO
    {
        public ContactMeFormType Type { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Message { get; set; }
    }
}
