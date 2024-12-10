using Alfateam.Telephony.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExtLines
{
    public class FromServiceToServerExtLine : ExtLine
    {
        public string IP { get; set; }
        public string? SIPDomain { get; set; }

        public short Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
