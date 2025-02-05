using Alfateam.Telephony.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General
{
    public class LanguageDTO : DTOModelAbs<Language>
    {
        public string Title { get; set; }
        public string LangCode { get; set; }
    }
}
