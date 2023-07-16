using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM {
    public enum OrderStatus {
        [Description("Активный")]
        Active = 1,
        [Description("Завершен")]
        Finished = 2,
        [Description("Приостановлен")]
        Suspended = 3,
        [Description("Переговоры")]
        Negotiations = 4,
        [Description("Прекращен/не реализован")]
        Broken = 5,
        [Description("Отклонен командой Alfateam")]
        RejectedByAlfateam = 6,
        [Description("Отклонен клиентом")]
        RejectedByClient = 7,
        [Description("Не договорились")]
        CouldNotTaken = 8,
    }
}
