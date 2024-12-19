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
        public SentSmsStatus(SentSmsStatusType status, string? responseText = null)
        {
            Status = status;
            ResponseText = responseText;
        }

        public SentSmsStatusType Status { get; set; }
        public string? ResponseText { get; set; }
    }
}
