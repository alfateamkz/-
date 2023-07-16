using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums
{
    /// <summary>
    /// Тип штрафа по договорным или иным обязательствам
    /// </summary>
    public enum PenaltyType
    {
        FixedValue = 1, //Фиксированный штраф
        PercentForTotal = 2, //Процент от общей суммы договора
        PercentForMilestone = 3, //Процент от суммы этапа договора
        PercentForSumOfPayment = 4, //Процент от суммы платежа
        PercentForTotalRemain = 5, //Процент от общей оставшиеся суммы договора
    }
}
