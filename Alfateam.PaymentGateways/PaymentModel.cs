using Alfateam.PaymentGateways.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.PaymentGateways
{
    public class PaymentModel
    {
        public string Id { get; set; }
        public PaymentStatusType Status { get; set; }



        public decimal Sum { get; set; }
        public string CurrencyCode { get; set; }



    }
}
