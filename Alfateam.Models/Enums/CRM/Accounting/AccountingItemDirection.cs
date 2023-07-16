using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM.Accounting {
    public enum AccountingItemDirection {
        [Description("Доход")]
        Income = 1,
        [Description("Расход")]
        Expense = 2
    }
}
