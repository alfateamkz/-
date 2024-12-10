using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions.VoiceMenu
{
    public class VoiceMenuYesNoItem : VoiceMenuItem
    {
        public VoiceMenuItem? YesConditionItem { get; set; }
        public VoiceMenuItem? NoConditionItem { get; set; }
    }
}
