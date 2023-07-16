using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Marketing
{
    /// <summary>
    /// Статус пункта рекламной кампании
    /// </summary>
    public enum AdCampaignItemStatus
    {
        Planned = 1, //Запланирована
        NotStarted = 2, //Не начата
        Active = 3, //Активна
        Suspended = 4, //Приостановлена
        Completed = 5, //Завершена
        Canceled = 6 //Отменена
    }
}
