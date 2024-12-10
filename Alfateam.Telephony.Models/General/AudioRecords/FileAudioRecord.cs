using Alfateam.Telephony.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General.AudioRecords
{
    public class FileAudioRecord : AudioRecord
    {
        public string Title { get; set; }
        public string Filepath { get; set; }
    }
}
