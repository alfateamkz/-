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
    /// Сущность долевого условия по инвестиции 
    /// </summary>
    public class EquityInvestmentCondition : InvestmentCondition
    {
        public double Equity { get; set; }
        public EquityInvestmentType Type { get; set; } = EquityInvestmentType.ProfitEquity;
    }
}
