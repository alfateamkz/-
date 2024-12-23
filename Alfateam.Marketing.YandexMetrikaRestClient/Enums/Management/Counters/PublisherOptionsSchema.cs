using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters
{
    public enum PublisherOptionsSchema
    {
        [Description("microdata")]
        MicroData = 1,
        [Description("json_ld")]
        JSONLD = 2,
        [Description("opengraph")]
        OpenGraph = 3,
    }
}
