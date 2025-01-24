using Alfateam.Telephony.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.HLR.Numbers.Types
{
    public class HLRNumbersToCheckCategories : HLRNumberToCheck
    {
        public List<ContactCategory> Categories { get; set; } = new List<ContactCategory>();
        public List<HLRNumberToCheck> IgnoreNumbers { get; set; } = new List<HLRNumberToCheck>();
    }
}
