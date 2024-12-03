using Alfateam.SMSGateways.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways
{
    public class SentSmsStatus
    {
        public SentSmsStatusType Status { get; set; }
        public string? ResponseText { get; set; }
    }
}
