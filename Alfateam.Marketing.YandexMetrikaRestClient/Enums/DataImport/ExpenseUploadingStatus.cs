using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum ExpenseUploadingStatus
    {
        [Description("UPLOADED")]
        Uploaded = 1,
        [Description("IN_PROGRESS")]
        InProgress = 2,
        [Description("PROCESSED")]
        Processed = 3
    }
}
