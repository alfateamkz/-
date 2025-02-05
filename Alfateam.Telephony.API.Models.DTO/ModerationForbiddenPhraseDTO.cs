using Alfateam.Telephony.Models;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO
{
    public class ModerationForbiddenPhraseDTO : DTOModelAbs<ModerationForbiddenPhrase>
    {
        public string Phrase { get; set; }
    }
}
