using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.PaymentGateways
{
    public class PaymentCreationModel
    {
        public decimal Sum { get; set; }
        public string CurrencyCode { get; set; }
    }
}
