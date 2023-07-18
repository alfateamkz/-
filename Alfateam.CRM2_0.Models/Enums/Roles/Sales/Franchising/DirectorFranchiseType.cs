using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Sales.Franchising
{
    /// <summary>
    /// Тип франшизы, где ее владелец получает ЗП и процент
    /// </summary>
    public enum DirectorFranchiseType
    {
        PercentForRevenue = 1, //Процент с выручки
        PercentForProfit = 2, //Процент с дохода
    }
}
