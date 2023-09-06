using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Accountance
{
    public class AccountClientModel : ClientModel<Account>
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тип счета
        /// </summary>
        public AccountType Type { get; set; }

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
        public CurrencyClientModel Currency { get; set; }
    }
}
