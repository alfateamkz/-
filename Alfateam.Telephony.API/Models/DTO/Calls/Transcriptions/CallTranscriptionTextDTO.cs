using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.Calls.Transcriptions;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Calls.Transcriptions
{
    public class CallTranscriptionTextDTO : DTOModelAbs<CallTranscriptionText>
    {

        [ForClientOnly]
        public CallTranscriptionCompanionDTO Companion { get; set; }

        [HiddenFromClient]
        public int CompanionId { get; set; }



        public TimeSpan Timecode { get; set; }
        public string Text { get; set; }
    }
}
