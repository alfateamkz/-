using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport
{
    public enum UploadingFormat
    {
        [Description("JSON")]
        JSON = 1,
        [Description("CSV")]
        CSV = 2,
    }
}
