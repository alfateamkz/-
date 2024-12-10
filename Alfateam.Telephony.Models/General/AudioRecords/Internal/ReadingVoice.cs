using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General.AudioRecords.Internal
{
    public class ReadingVoice : AbsModel
    {
        public Language Language { get; set; }
        public int LanguageId { get; set; }



        public string Title { get; set; }
        public string ReadingProcessorFilepath { get; set; }
    }
}
