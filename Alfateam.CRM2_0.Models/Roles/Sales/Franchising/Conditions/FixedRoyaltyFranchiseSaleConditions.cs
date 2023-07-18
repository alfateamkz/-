using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Conditions
{
    /// <summary>
    /// Условия платежей по франшизе с фиксированным роялти
    /// </summary>
    public class FixedRoyaltyFranchiseSaleConditions : RoyaltyFranchiseSaleConditions
    {
        public Cost Royalty { get; set; }
    }
}
