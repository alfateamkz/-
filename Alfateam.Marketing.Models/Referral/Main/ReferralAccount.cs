using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral.Main
{
    public class ReferralAccount : AbsModel
    {
        public string CurrencyCode { get; set; }
        public List<ReferralAccountTransaction> Transactions { get; set; } = new List<ReferralAccountTransaction>();
    }
}
