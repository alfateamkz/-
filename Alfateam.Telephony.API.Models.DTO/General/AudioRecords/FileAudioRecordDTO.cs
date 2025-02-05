using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General.AudioRecords
{
    public class FileAudioRecordDTO : AudioRecordDTO
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string Filepath { get; set; }
    }
}
