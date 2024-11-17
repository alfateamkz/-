using Alfateam.PaymentGateways.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.PaymentGateways.Countries.Kazakhstan
{
    public class Kassa24PaymentGateway : IPaymentGateway
    {
        public CreatedPaymentModel CreatePayment(PaymentCreationModel payment)
        {
            throw new NotImplementedException();
        }

        public PaymentModel GetPayment(string id)
        {
            throw new NotImplementedException();
        }
    }
}
