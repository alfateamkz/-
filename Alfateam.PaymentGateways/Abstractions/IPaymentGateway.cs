using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.PaymentGateways.Abstractions
{
    public interface IPaymentGateway
    {
        CreatedPaymentModel CreatePayment(PaymentCreationModel payment);
        PaymentModel GetPayment(string id);

    }
}
