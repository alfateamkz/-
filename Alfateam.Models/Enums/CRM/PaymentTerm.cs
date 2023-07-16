using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM {
    public enum PaymentTerm {
        [Description("Раз в неделю")]
        Weekly = 1,
        [Description("Раз в полмесяца")]
        HalfMonthly = 2,
        [Description("Раз в месяц")]
        Monthly = 3,
        [Description("Попроектно")]
        ByProject = 4,
    }
}
