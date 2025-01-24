using Alfateam.Telephony.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Calls.Types
{
    public class IncomingCall : BaseCall
    {
        public string From { get; set; }
    }
}
