using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals
{
    /// <summary>
    /// Статус действия по результату обращения в службу комплаенс
    /// </summary>
    public enum AppealResultActionStatus
    {
        NotPerformed = 1, //Не выполнено
        Performing = 2, //Выполняется
        Performed = 3, //Выполнено
    }
}
