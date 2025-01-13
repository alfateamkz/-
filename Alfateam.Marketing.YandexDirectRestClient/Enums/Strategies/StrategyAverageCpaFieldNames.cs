using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum StrategyAverageCpaFieldNames
    {
        [Description("AverageCpc")]
        AverageCpc = 1,
        [Description("GoalId")]
        GoalId = 2,
        [Description("WeeklySpendLimit")]
        WeeklySpendLimit = 3,
        [Description("BidCeiling")]
        BidCeiling = 4,
        [Description("ExplorationBudget")]
        ExplorationBudget = 5,
        [Description("CustomPeriodBudget")]
        CustomPeriodBudget = 6,
        [Description("BudgetType")]
        BudgetType = 7,
    }
}
