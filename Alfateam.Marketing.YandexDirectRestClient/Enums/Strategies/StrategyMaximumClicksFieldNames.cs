using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum StrategyMaximumClicksFieldNames
    {
        [Description("WeeklySpendLimit")]
        WeeklySpendLimit = 1,
        [Description("BidCeiling")]
        BidCeiling = 2,
        [Description("CustomPeriodBudget")]
        CustomPeriodBudget = 3,
        [Description("BudgetType")]
        BudgetType = 4,
    }
}
