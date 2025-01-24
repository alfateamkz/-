using Alfateam.Core;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.SMS
{
    public class SentSMS : BaseSMS
    {
        public User SentBy { get; set; }
        public int SentById { get; set; }


        public DateTime SentAt { get; set; }
        public string To { get; set; }
    }
}
