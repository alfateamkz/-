using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.InSearch
{
    public enum ApiSearchEventEnum
    {
        [Description("APPEARED_IN_SEARCH")]
        AppearedInSearch = 1,
        [Description("REMOVED_FROM_SEARCH")]
        RemovedFromSearch = 2
    }
}
