using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM.Orders {
    public enum OrderStageTaskStatus {
        [Description("Не начато")]
        NotStarted = 1,
        [Description("В работе")]
        InWork = 2,
        [Description("Проверка")]
        Check = 3,
        [Description("Тестирование")]
        Testing = 4,
        [Description("В доработке")]
        Revision = 5,
        [Description("Завершен")]
        Done = 6,
        [Description("Отложено")]
        Postponed = 7,
    }
}
