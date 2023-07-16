using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance
{
    /// <summary>
    /// Модель счета фирмы
    /// </summary>
    public class Account : AbsModel
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип счета
        /// </summary>
        public AccountType Type { get; set; } = AccountType.Regular;

        /// <summary>
        /// Платежные реквизиты
        /// </summary>
        public string PaymentInfo { get; set; }


        /// <summary>
        /// Название банка
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// Валюта счета
        /// </summary>
        public Currency Currency { get; set; }



        /// <summary>
        /// Движения по счету
        /// </summary>
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
