using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising
{
    /// <summary>
    /// Сущность прайсов по франшизе по разным странам
    /// </summary>
    public class FranchisePricing : AbsModel
    {
        public List<PricingItem> PriceByCountries { get; set; } = new List<PricingItem>();
    }
}
