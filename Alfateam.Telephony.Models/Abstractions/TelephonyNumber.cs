using Alfateam.Core;
using Alfateam.Telephony.Models.Calls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions
{
    public class TelephonyNumber : AbsModel
    {
        public string PhoneNumber { get; set; }


        public List<Call> Calls { get; set; } = new List<Call>();
        public List<BaseSMS> SMSList { get; set; } = new List<BaseSMS>();
    }
}
