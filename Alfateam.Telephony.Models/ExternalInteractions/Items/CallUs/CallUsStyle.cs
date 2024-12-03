using Alfateam.Core;
using Alfateam.Telephony.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.CallUs
{
    public class CallUsStyle : AbsModel
    {
        public string Fonts { get; set; }
        public CallUsStyleFormType FormType { get; set; }



        public CallUsStyleColors InitialStateColors { get; set; }
        public CallUsStyleColors DialingStateColors { get; set; }
        public CallUsStyleColors ActiveStateColors { get; set; }
        public CallUsStyleColors EndedStateColors { get; set; }
    
    }
}
