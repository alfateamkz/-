using Alfateam.ID.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.ID.Models.Payments
{
    public class Payment : AbsModel
    {
        public PaymentStatus Status { get; set; } = PaymentStatus.NotPaidYet;
        public DateTime? PaidAt { get; set; }


        public string CurrencyCode { get; set; }    
        public decimal Sum { get; set; }
        public string Comment { get; set; }
        public string? ProductIdentifier { get; set; }



        public User User { get; set; }
        public int UserId { get; set; }

    }
}
