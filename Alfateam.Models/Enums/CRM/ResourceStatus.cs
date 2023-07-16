using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Enums.CRM {
    public enum ResourceStatus {
        [Description("Свободен")]
        Available = 1,
        [Description("Занят")]
        Occupied = 2,
        [Description("Недоступен")]
        Unavailable = 3,
        [Description("Утрачен")]
        Lost = 4,
        [Description("Прочее")]
        Other = 5
    }
}
