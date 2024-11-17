using Alfateam.PaymentGateways.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.PaymentGateways.Countries.Russia
{
    public class YookassaPaymentGateway : IPaymentGateway
    {

        public readonly string API_KEY;
        public readonly int SHOP_ID;

        public YookassaPaymentGateway(string apiKey, int shopId)
        {
            API_KEY = apiKey;
            SHOP_ID = shopId;
        }


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
