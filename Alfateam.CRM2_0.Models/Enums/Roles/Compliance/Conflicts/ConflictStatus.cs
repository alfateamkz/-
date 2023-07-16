using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Статус конфликта
    /// </summary>
    public enum ConflictStatus
    {
        Opened = 1, //Конфликт возник
        Active = 2, //Конфликт решается
        Resolved = 3, //Получено общее соглашение по урегулированию
        NotResolved = 4, //Не получено общее соглашение по урегулированию
        Closed = 5, //Конфликт закрыт
        Canceled = 6, //Конфликт отменен
    }
}
