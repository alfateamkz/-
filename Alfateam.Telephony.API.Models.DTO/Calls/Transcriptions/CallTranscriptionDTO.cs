using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.Calls.Transcriptions;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Calls.Transcriptions
{
    public class CallTranscriptionDTO : DTOModelAbs<CallTranscription>
    {

        [ForClientOnly]
        public string MainLangCode { get; set; }

        [ForClientOnly]
        public List<CallTranscriptionCompanionDTO> Companions { get; set; } = new List<CallTranscriptionCompanionDTO>();

        [ForClientOnly]
        public List<CallTranscriptionTextDTO> Texts { get; set; } = new List<CallTranscriptionTextDTO>();
    }
}
