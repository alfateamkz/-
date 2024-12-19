using Alfateam.SMSGateways.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways
{
    public class GetBalanceStatus
    {
        public GetBalanceStatus(GetBalanceStatusType status, string? message)
        {
            Status = status;
            Message = message;
        }
        public GetBalanceStatus(GetBalanceStatusType status, string? message, string currencyCode, double balance)
        {
            Status = status;
            Message = message;
            CurrencyCode = currencyCode;
            Balance = balance;
        }

        public GetBalanceStatusType Status { get; set; }
        public string? Message { get; set; }






        public string? CurrencyCode { get; set; }
        public double? Balance { get; set; }
    }
}
