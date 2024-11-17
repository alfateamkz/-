using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.PaymentGateways
{
    public class CreatedPaymentModel 
    {
        public string Id { get; set; }


        public decimal Sum { get; set; }
        public string CurrencyCode { get; set; }


    }
}
