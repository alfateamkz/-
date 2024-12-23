using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums
{
    public enum ApiHostDataStatus
    {
        [Description("NOT_INDEXED")]
        NotIndexed = 1,
        [Description("NOT_LOADED")]
        NotLoaded = 2,
        [Description("OK")]
        Ok = 3
    }
}
