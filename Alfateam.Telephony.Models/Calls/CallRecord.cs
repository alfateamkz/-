using Alfateam.Core;
using Alfateam.Telephony.Models.Calls.Transcriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Calls
{
    public class CallRecord : AbsModel
    {
        public string RecordPath { get; set; }
        public int FileSizeInKBs { get; set; }



        public CallTranscription? Transcription { get; set; }
    }
}
