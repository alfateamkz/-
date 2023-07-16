using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales
{
    /// <summary>
    /// Статус созвона с клиентом
    /// </summary>
    public enum CustomerCallStatus
    {
        Planned = 1, //Запланирован
        Active = 2, //Созвон идет прямо сейчас
        Completed = 3, //Завершен
        Failed = 4, //Несостоялся
        Postponed = 5 //Перенесен
    }
}
