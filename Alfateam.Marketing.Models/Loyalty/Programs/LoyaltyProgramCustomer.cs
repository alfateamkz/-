using Alfateam.Core;
using Alfateam.Marketing.Models.Loyalty.Programs.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Loyalty.Programs
{
    public class LoyaltyProgramCustomer : AbsModelGuid
    {
        public string? ExternalId { get; set; }
        public List<LoyaltyProgramTransaction> Transactions { get; set; } = new List<LoyaltyProgramTransaction>();
    }
}
