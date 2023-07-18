using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising
{
    /// <summary>
    /// Сущность схемы платежей роялти
    /// </summary>
    public class FranchiseRoyaltyScheme : AbsModel
    {
        public FranchisePricing MonthlyPaymentForOffice { get; set; }
        public List<FranchiseRoyaltySchemeItem> EmployeeCountGrades { get; set; } = new List<FranchiseRoyaltySchemeItem>();
    }
}
