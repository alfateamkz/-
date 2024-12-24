using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing
{
    public enum ApiExcludedUrlStatus
    {
        [Description("NOTHING_FOUND")]
        NothingFound = 1,
        [Description("HOST_ERROR")]
        HostError = 2,
        [Description("REDIRECT_NOTSEARCHABLE")]
        RedirectNotSearchable = 3,
        [Description("HTTP_ERROR")]
        HTTPError = 4,
        [Description("NOT_CANONICAL")]
        NotCanonical = 5,
        [Description("NOT_MAIN_MIRROR")]
        NotMainMirror = 6,
        [Description("PARSER_ERROR")]
        ParserError = 7,
        [Description("ROBOTS_HOST_ERROR")]
        RobotsHostError = 8,
        [Description("ROBOTS_URL_ERROR")]
        RobotsURLError = 9,
        [Description("DUPLICATE")]
        Duplicate = 10,
        [Description("LOW_QUALITY")]
        LowQuality = 11,
        [Description("CLEAN_PARAMS")]
        CleanParams = 12,
        [Description("NO_INDEX")]
        NoIndex = 13,

        [Description("OTHER")]
        Other = 999,
    }
}
