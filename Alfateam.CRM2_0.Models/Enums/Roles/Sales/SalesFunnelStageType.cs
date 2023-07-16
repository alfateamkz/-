using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales
{
    /// <summary>
    /// Тип этапа воронки продаж
    /// </summary>
    public enum SalesFunnelStageType
    {
        Awareness = 1, //Осведомленность
        Interest = 2, //Интерес
        Negotiations = 3, //Переговоры
        ContractDiscussion = 4, //Обсуждение условий договора
        Sale = 5, //Продажа
    }
}
