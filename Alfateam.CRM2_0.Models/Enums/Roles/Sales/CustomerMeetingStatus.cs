using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales
{
    /// <summary>
    /// Статус встречи с клиентом
    /// </summary>
    public enum CustomerMeetingStatus
    {
        Planned = 1, //Запланирована
        Active = 2, //Встреча идет прямо сейчас
        Completed = 3, //Завершена
        Failed = 4, //Несостоялась
        Postponed = 5 //Перенесена
    }
}
