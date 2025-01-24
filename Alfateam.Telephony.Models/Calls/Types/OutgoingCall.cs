using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Calls.Types
{
    public class OutgoingCall : BaseCall
    {
        public User CallMadeBy { get; set; }
        public int CallMadeById { get; set; }


        public string To { get; set; }
    }
}
