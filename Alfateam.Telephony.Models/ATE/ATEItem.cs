using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ATE
{
    public class ATEItem : AbsModel
    {
        public string DisplayedName { get; set; }
        public int InternalNumber { get; set; }


        public bool IsSupervisorEnabled { get; set; }
    }
}
