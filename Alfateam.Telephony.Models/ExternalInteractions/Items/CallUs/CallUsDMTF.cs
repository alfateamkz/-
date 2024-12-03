using Alfateam.Core;
using Alfateam.Telephony.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.CallUs
{
    public class CallUsDMTF : AbsModel
    {
        public bool IsEnabled { get; set; }
        public CallUsDMTFType Type { get; set; }
        public int ShowTimeInSeconds { get; set; }
    }
}
