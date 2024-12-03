using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Referral.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral
{
    public class MLMNetworkReferralProgram : ReferralProgram
    {
        public List<MLMNetworkReferralProgramLevel> Levels { get; set; } = new List<MLMNetworkReferralProgramLevel>();
    }
}
