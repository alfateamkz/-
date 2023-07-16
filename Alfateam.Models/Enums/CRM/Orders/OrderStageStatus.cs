using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM {
    public enum OrderStageStatus {
        [Description("Не начат")]
        NotStarted = 1,
        [Description("Анализ")]
        Analysis = 2,
        [Description("Брифинг")]
        Briefing = 3,
        [Description("В работе")]
        InWork = 4,
        [Description("Приемка")]
        Acceptance = 5,
        [Description("В доработке")]
        Revision = 6,
        [Description("Завершен")]
        Finished = 7,
    }
}
