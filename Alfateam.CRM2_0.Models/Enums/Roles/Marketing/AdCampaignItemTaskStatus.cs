using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Marketing
{
    /// <summary>
    /// Статус задачи пункта рекламной кампании
    /// </summary>
    public enum AdCampaignItemTaskStatus 
    {
        NotStarted = 1, //Не начата
        Active = 2, //В работе
        Review = 3, //Проверка выполнения
        Revision = 4, //Доработка
        Completed = 5, //Завершена
        Canceled = 6, //Отменена
        Postponed = 7, //Отложена
    }
}
