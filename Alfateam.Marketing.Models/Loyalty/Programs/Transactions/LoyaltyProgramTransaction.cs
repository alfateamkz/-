using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Loyalty.Programs.Transactions
{
    public class LoyaltyProgramTransaction : AbsModel
    {
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
        public double Sum { get; set; }
        public double LoyaltyProgramBaseCurrencySum { get; set; }
        public double LoyaltyProgramPercent { get; set; }
        public TransactionDirection Direction { get; set; }
        public string Comment { get; set; }
        public DateTime CommittedAt { get; set; }



        [NotMapped]
        public double Reward => LoyaltyProgramBaseCurrencySum / 100 * LoyaltyProgramBaseCurrencySum;
    }
}
