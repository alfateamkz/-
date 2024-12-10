using Alfateam.Telephony.Models.Abstractions.VoiceMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ATE.VoiceMenu
{
    public class VoiceMenu : VoiceMenuItem
    {
        public VoiceMenuItem? Button1 { get; set; }
        public VoiceMenuItem? Button2 { get; set; }
        public VoiceMenuItem? Button3 { get; set; }
        public VoiceMenuItem? Button4 { get; set; }
        public VoiceMenuItem? Button5 { get; set; }
        public VoiceMenuItem? Button6 { get; set; }
        public VoiceMenuItem? Button7 { get; set; }
        public VoiceMenuItem? Button8 { get; set; }
        public VoiceMenuItem? Button9 { get; set; }
        public VoiceMenuItem? Button0 { get; set; }

        public VoiceMenuItem? ButtonNotPressed { get; set; }
    }
}
