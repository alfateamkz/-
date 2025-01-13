using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    
    public enum StrategyAverageCpcFieldNames
    {
        [Description("AverageCpc")]
        AverageCpc = 1,
        [Description("WeeklySpendLimit")]
        WeeklySpendLimit = 2,
        [Description("CustomPeriodBudget")]
        CustomPeriodBudget = 3,
        [Description("BudgetType")]
        BudgetType = 4,
    }
}
