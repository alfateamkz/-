using Alfateam.Telephony.API.Models.DTO.Calls.Transcriptions;
using Alfateam.Telephony.Models.Calls;
using Alfateam.Telephony.Models.Calls.Transcriptions;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.Calls
{
    public class CallRecordDTO : DTOModelAbs<CallRecord>
    {
        public string RecordPath { get; set; }
        public int FileSizeInKBs { get; set; }



        public CallTranscriptionDTO? Transcription { get; set; }
    }
}
