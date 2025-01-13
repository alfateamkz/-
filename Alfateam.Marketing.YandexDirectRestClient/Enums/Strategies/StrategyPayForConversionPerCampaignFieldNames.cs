using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum StrategyPayForConversionPerCampaignFieldNames
    {
        [Description("Cpa")]
        Cpa = 1,
        [Description("GoalId")]
        GoalId = 2,
        [Description("WeeklySpendLimit")]
        WeeklySpendLimit = 3,
        [Description("CustomPeriodBudget")]
        CustomPeriodBudget = 4,
        [Description("BudgetType")]
        BudgetType = 5,
    }
}
