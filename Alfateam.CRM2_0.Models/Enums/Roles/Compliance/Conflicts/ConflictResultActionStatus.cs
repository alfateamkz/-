using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Статус необходимого действия, которое было определено по результату конфликта
    /// </summary>
    public enum ConflictResultActionStatus
    {
        NotPerformed = 1, //Действие не выполнено
        Performed = 2, //Действие выполнено
    }
}
