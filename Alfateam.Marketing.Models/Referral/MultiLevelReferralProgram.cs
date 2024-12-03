using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Referral.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral
{
    public class MultiLevelReferralProgram : ReferralProgram
    {
        public ReferralProgramTresholdType MetricType { get; set; }
        public List<MultiLevelReferralProgramLevel> Levels { get; set; } = new List<MultiLevelReferralProgramLevel>();
    }
}
