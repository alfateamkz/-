using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Franchising;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Franchises
{
    /// <summary>
    /// Сущность франшизы с процентным роялти
    /// </summary>
    public class PercentRoyaltyFranchise : Franchise
    {
        public PercentRoyaltyFranchiseType Type { get; set; } = PercentRoyaltyFranchiseType.PercentForRevenue;
        public FranchisePricing EntryFee { get; set; }
        public double Percent { get; set; }


    }
}
