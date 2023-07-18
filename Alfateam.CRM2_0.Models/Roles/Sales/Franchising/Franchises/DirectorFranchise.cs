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
    /// Сущность франшизы, где ее владелец получает ЗП и процент
    /// </summary>
    public class DirectorFranchise : Franchise
    {
        public DirectorFranchiseType Type { get; set; } = DirectorFranchiseType.PercentForRevenue;

        public FranchisePricing Salary { get; set; }
        public double Percent { get; set; }
       
    }
}
