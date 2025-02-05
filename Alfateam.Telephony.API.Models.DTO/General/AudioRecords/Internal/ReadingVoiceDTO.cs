using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.General.AudioRecords.Internal;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General.AudioRecords.Internal
{
    public class ReadingVoiceDTO : DTOModelAbs<ReadingVoice>
    {

        [ForClientOnly]
        public LanguageDTO Language { get; set; }

        [HiddenFromClient]
        public int LanguageId { get; set; }



        public string Title { get; set; }

        [ForClientOnly]
        public string ReadingProcessorFilepath { get; set; }
    }
}
