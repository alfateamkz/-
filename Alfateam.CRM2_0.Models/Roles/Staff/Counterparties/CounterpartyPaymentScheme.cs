using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Staff.Counterparties;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff.Counterparties
{
    public class CounterpartyPaymentScheme : AbsModel
    {
        public CounterpartyPaymentSchemeType Type { get; set; } = CounterpartyPaymentSchemeType.PostPaymentForMilestone;

        /// <summary>
        /// Процент предоплаты
        /// </summary>
        public double? UpfrontPaymentPercent { get; set; }

        /// <summary>
        /// Предпочтительный способ оплаты
        /// </summary>
        public PaymentType PreferedPaymentType { get; set; } = PaymentType.Cashless;


        /// <summary>
        /// Основная валюта контрагента
        /// </summary>
        public Currency MainCurrency { get; set; }


        /// <summary>
        /// Минимальная сумма, с которой контрагент готов работать
        /// </summary>
        public Cost? MinumumSumOfProject { get; set; }
    }
}
