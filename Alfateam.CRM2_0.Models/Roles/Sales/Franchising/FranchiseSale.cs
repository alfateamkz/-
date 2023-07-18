using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales.Franchising;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Franchises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising
{
    /// <summary>
    /// Сущность продажи франшизы
    /// </summary>
    public class FranchiseSale : AbsModel
    {
        public Franchise Franchise { get; set; }
        public User Customer { get; set; }
        public FranchiseSaleStatus Status { get; set; } = FranchiseSaleStatus.Lead;


        public FranchiseSaleConditionsGroup Conditions { get; set; }

        /// <summary>
        /// Сам бизнес по франшизе
        /// Не равно null, если заключен договор и выполены стартовые условия
        /// </summary>
        public Business? Business { get; set; }
    }
}
