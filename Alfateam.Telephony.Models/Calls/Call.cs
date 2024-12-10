using Alfateam.Core;
using Alfateam.Telephony.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Calls
{
    public class Call : AbsModel
    {
        public User CallMadeBy { get; set; }
        public int CallMadeById { get; set; }


        public string To { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }



        public CallRecord? Record { get; set; }
        public string? Comment { get; set; }
        
    }
}
