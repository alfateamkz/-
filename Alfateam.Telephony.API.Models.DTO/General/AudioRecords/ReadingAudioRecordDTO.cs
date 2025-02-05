using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.General.AudioRecords.Internal;
using Alfateam.Telephony.Models.General.AudioRecords;
using Alfateam.Telephony.Models.General.AudioRecords.Internal;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General.AudioRecords
{
    public class ReadingAudioRecordDTO : DTOModelAbs<ReadingAudioRecord>
    {
        public string Title { get; set; }
        public string Text { get; set; }


        [ForClientOnly]
        public ReadingVoiceDTO ReadingVoice { get; set; }

        [HiddenFromClient]
        public int ReadingVoiceId { get; set; }
    }
}
