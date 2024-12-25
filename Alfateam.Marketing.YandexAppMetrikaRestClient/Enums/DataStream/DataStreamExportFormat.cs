using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.DataStream
{
    public enum DataStreamExportFormat
    {
        [Description("csv")]
        CSV = 1,
        [Description("json")]
        JSON = 2
    }
}
