using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum BudgetTypeEnum
    {
        [Description("WEEKLY_BUDGET")]
        WeeklyBudget = 1,
        [Description("CUSTOM_PERIOD_BUDGET")]
        CustomPeriodBudget = 2,
    }
}
