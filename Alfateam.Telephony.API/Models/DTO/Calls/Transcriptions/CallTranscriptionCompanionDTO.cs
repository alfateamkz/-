using Alfateam.Telephony.Models.Calls.Transcriptions;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Calls.Transcriptions
{
    public class CallTranscriptionCompanionDTO : DTOModelAbs<CallTranscriptionCompanion>
    {
        public string Title { get; set; }
        public CompanionGender? Gender { get; set; }
    }
}
