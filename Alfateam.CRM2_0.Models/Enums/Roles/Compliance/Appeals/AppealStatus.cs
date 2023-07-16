using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals
{
    /// <summary>
    /// Статус обращения в службу комплаенс
    /// </summary>
    public enum AppealStatus
    {
        Waiting = 1, //В ожидании рассмотрения
        Consideration = 2, //Рассматривается
        ConsiderationCompleted = 3, //Обращение обработано, принимаются меры по обращению
        Resolved = 4, //Обращение обработано и приняты решения по обращению
        Canceled = 5, //Обращение отменено заявителем
    }
}
