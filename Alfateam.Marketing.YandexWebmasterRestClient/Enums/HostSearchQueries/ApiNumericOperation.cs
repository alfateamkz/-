using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries
{
    public enum ApiNumericOperation
    {
        [Description("LESS_THAN")]
        LessThan = 1,
        [Description("GREATER_THAN")]
        GreaterThan = 2,
        [Description("LESS_EQUAL")]
        LessEqual = 3,
        [Description("GREATER_EQUAL")]
        GreaterEqual = 4,
        [Description("EQUAL")]
        Equal = 5
    }
}
