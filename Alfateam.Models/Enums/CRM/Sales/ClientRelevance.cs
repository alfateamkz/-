using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM.Sales {

    /// <summary>
    /// Актуальность клиента. Вычисляется по дате добавления, заказам и их стоимости
    /// </summary>
    public enum ClientRelevance {
        [Description("Новый")]
        New =1,
        [Description("Прогрев")]
        WarmingUp = 2,
        [Description("Актуальный")]
        Relevant = 3,
        [Description("Старый клиент")]
        OldRelevant = 4,
        [Description("Не актуальный")]
        NotRelevant = 5,
        [Description("Работали давно")]
        OldNotRelevant = 6,
    }
}
