using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Accountance;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.Accountance
{
    public class AccountEditModel : EditModel<Account>
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
    }
}
