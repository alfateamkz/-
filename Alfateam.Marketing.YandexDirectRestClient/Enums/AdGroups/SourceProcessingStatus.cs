using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups
{
    public enum SourceProcessingStatus
    {
        [Description("EMPTY_RESULT")]
        EmptyResult = 1,
        [Description("PROCESSED")]
        Processed = 2,
        [Description("UNKNOWN")]
        Unknown = 3,
        [Description("UNPROCESSED")]
        Unprocessed = 4,
    }
}
