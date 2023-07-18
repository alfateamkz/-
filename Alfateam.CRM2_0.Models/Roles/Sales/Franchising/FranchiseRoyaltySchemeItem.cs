using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising
{
    /// <summary>
    /// Грейды по франшизе
    /// Например. От 1 до 10 сотрудников одна цена, от 11 до 20 - другая
    /// </summary>
    public class FranchiseRoyaltySchemeItem : AbsModel
    {
        public int From { get; set; }
        public int To { get; set; }

        public FranchisePricing? Price { get; set; }
    }
}
