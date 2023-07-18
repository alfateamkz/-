using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales.Franchising
{
    /// <summary>
    /// Тип франшизы с процентным роялти
    /// </summary>
    public enum PercentRoyaltyFranchiseType
    {
        PercentForRevenue = 1, //Процент с выручки
        PercentForProfit = 2, //Процент с дохода
    }
}
