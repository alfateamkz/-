using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.ExternalInteractions.Items.CallUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions
{
    public class CallUsExtInteraction : ExtInteraction
    {
        public string ButtonText { get; set; }
        public string TextFromUnsupportedBrowsers { get; set; }
        public CallUsDMTF DMTF { get; set; }

        public CallUsStyle Style { get; set; }
    }
}
