using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum ExpenseUploadingType
    {
        [Description("EXPENSES")]
        Expenses = 1,
        [Description("REMOVES")]
        Removes = 2
    }
}
