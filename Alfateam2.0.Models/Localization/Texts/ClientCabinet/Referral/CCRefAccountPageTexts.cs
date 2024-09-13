using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral
{
    public class CCRefAccountPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "История транзакций";

        public string TransactionAdmission { get; set; } = "Зачисление средств по заказу {order_title}";
        public string TransactionWithdrawalIndividual { get; set; } = "Вывод средств на карту {cardNumber}";
        public string TransactionWithdrawalLegalEntity { get; set; } = "Вывод средств на счет {accountNumber} компании {companyName}";
    }
}
