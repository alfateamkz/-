using Alfateam.Marketing.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral.Main.Transactions
{
    public class AdmissionReferralAccountTransaction : ReferralAccountTransaction
    {
        public string ExtOrderId { get; set; }
        public string OrderInfo { get; set; }
    }
}
