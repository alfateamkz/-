using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum StrategyAverageCpcPerFilterFieldNames
    {
        [Description("FilterAverageCpc")]
        FilterAverageCpc = 1,
        [Description("WeeklySpendLimit")]
        WeeklySpendLimit = 2,
        [Description("BidCeiling")]
        BidCeiling = 3,
        [Description("CustomPeriodBudget")]
        CustomPeriodBudget = 4,
        [Description("BudgetType")]
        BudgetType = 5,
    }
}
