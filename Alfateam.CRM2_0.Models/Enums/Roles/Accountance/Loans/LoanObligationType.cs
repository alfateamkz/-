using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Accountance.Loans
{
    /// <summary>
    /// Тип заемного обязательства
    /// </summary>
    public enum LoanObligationType
    {
        Loan = 1, //Займ
        Credit = 2, //Кредит
        Factoring = 3, //Факторинг
        Investment = 4, //Инвестиция

        Other = 999, //Иные заимстования
    }
}
