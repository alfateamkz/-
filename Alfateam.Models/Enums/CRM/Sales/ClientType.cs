using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM {
    public enum ClientType {

        [Description("Физическое лицо")]
        Individual = 1,
        [Description("Индивидуальный предпрениматель")]
        IE = 2,
        [Description("Юридическое лицо")]
        LLC = 3,
        [Description("Прочее")]
        Other = 4
    }
}
