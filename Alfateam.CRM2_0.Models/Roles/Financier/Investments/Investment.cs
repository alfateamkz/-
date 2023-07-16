using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Financier;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Investments
{
    /// <summary>
    /// Сущность нашей инвестиции
    /// </summary>
    public class Investment : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public Currency Currency { get; set; }
        public decimal InvestmentSum { get; set; }


        /// <summary>
        /// Условия по инвестиции. Депозитарная или долевая
        /// </summary>
        public InvestmentCondition InvestmentCondition { get; set; }
    }
}
