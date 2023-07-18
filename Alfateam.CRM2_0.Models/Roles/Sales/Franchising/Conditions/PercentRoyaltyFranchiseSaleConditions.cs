using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Conditions
{
    /// <summary>
    /// Условия платежей по франшизе с процентным роялти
    /// </summary>
    public class PercentRoyaltyFranchiseSaleConditions : RoyaltyFranchiseSaleConditions
    {  
        public double Percent { get; set; }
    }
}
