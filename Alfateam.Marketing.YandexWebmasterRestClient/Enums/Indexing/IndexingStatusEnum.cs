using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing
{
    public enum IndexingStatusEnum
    {
        [Description("HTTP_2XX")]
        HTTP_2XX = 1,
        [Description("HTTP_3XX")]
        HTTP_3XX = 2,
        [Description("HTTP_4XX")]
        HTTP_4XX = 3,
        [Description("HTTP_5XX")]
        HTTP_5XX = 4,
        [Description("OTHER")]
        Other = 5,
    }
}
