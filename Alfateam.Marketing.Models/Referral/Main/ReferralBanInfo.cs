using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral.Main
{
    public class ReferralBanInfo : AbsModel
    {
        public DateTime BannedBefore { get; set; }
        public string? BanReason { get; set; }
    }
}
