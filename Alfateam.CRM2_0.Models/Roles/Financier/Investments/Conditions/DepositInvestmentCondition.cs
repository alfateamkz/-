using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Financier;
using Alfateam.CRM2_0.Models.Enums.Roles.Financier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Investments.Conditions
{
    /// <summary>
    /// Сущность депозитарного условия по инвестиции 
    /// </summary>
    public class DepositInvestmentCondition : InvestmentCondition
    {
        public double? Percent { get; set; }
        /// <summary>
        /// Период процентной ставки
        /// </summary>
        public DepositInvestmentPercentPeriod Period { get; set; } = DepositInvestmentPercentPeriod.PercentForAnnum;


        /// <summary>
        /// Возможные сроки по инвестиции
        /// </summary>
        public List<InvestmentTerm> AllowedTerms { get; set; } = new List<InvestmentTerm>();


        /// <summary>
        /// Условия досрочного снятия
        /// </summary>
        public InvestmentEarlyWithdrawalCondition EarlyWithdrawalCondition { get; set; }
    }
}
