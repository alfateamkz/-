using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries
{
    public enum ApiTextualOperation
    {
        [Description("TEXT_CONTAINS")]
        TextContains = 1,
        [Description("TEXT_MATCH")]
        TextMatch = 2,
        [Description("TEXT_DOES_NOT_CONTAIN")]
        TextDoesNotContain = 3
    }
}
