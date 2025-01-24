using Alfateam.Telephony.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.HLR.Numbers.Types
{
    public class HLRNumbersToCheckList : HLRNumberToCheck
    {
        public HLRNumbersToCheckListType Type { get; set; }
        public List<HLRNumberToCheck> Numbers { get; set; } = new List<HLRNumberToCheck>();
    }
}
