using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum UserParamsUploadingStatus
    {
        [Description("is_processed")]
        IsProcessed = 1,
        [Description("processed")]
        Processed = 2,
        [Description("linkage_failure")]
        LinkageFailure = 3
    }
}
