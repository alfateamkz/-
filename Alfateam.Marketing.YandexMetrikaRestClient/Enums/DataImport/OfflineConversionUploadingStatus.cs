using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum OfflineConversionUploadingStatus
    {
        [Description("PREPARED")]
        Prepared = 1,
        [Description("UPLOADED")]
        Uploaded = 2,
        [Description("EXPORTED")]
        Exported = 3,
        [Description("MATCHED")]
        Matched = 4,
        [Description("PROCESSED")]
        Processed = 5,
        [Description("LINKAGE_FAILURE")]
        LinkageFailure = 6
    }
}
