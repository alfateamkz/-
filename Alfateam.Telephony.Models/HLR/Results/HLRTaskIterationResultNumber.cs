using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.HLR.Results
{
    public class HLRTaskIterationResultNumber : AbsModel
    {
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
