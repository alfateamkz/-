using Alfateam.ID.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.Payments.Ways
{
    public class BindedBankCard : BindedPaymentWay
    {
        public string First6Digits { get; set; }
        public string Last4Digits { get; set; }
        public string Token { get; set; }
    }
}
