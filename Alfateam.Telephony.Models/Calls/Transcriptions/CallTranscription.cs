using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Calls.Transcriptions
{
    public class CallTranscription : AbsModel
    {
         public string MainLangCode { get; set; }
         public List<CallTranscriptionCompanion> Companions { get; set; }= new List<CallTranscriptionCompanion>();

        
         public List<CallTranscriptionText> Texts { get; set; } = new List<CallTranscriptionText>();
    }
}
