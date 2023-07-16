using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM {
    public enum ResourceOwnership {
        [Description("Ресурс команды Alfateam")]
        Alfateam = 1,
        [Description("Ресурс клиента/прочее")]
        Other = 2,
    }
}
