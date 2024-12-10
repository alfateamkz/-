using Alfateam.Core;
using Alfateam.Telephony.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Calls.Transcriptions
{
    public class CallTranscriptionCompanion : AbsModel
    {
        public string Title { get; set; }
        public CompanionGender? Gender { get; set; }
    }
}
