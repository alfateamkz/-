using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing
{
    public enum ApiImportantUrlChangeIndicator
    {
        [Description("INDEXING_HTTP_CODE")]
        IndexingHTTPCode = 1,
        [Description("SEARCH_STATUS")]
        SearchStatus = 2,
        [Description("TITLE")]
        Title = 3,
        [Description("DESCRIPTION")]
        Description = 4
    }
}
