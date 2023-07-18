using Alfateam.CRM2_0.Models.Abstractions;
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
    /// Сущность франшизы с фиксированным роялти
    /// </summary>
    public class FixedRoyaltyFranchise : Franchise
    {
  
        public FranchisePricing EntryFee { get; set; }
        public FranchiseRoyaltyScheme Royalty { get; set; }

    }
}
