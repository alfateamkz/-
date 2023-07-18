using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Gamification
{
    /// <summary>
    /// Статус задания пользователю в системе геймификации
    /// </summary>
    public enum GamificationUserTaskStatus
    {
        Planned = 1, //Запланирована
        Active = 2, //Активна
        Completed = 3, //Выполнена
        Failed = 4, //Провалена
        Canceled = 5, //Отменена
    }
}
