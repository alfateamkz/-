using Alfateam.Telephony.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.SMS
{
    public class ReceivedSMS : BaseSMS
    {
        public string From { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
