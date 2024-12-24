using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Feeds
{
    public enum FeedLoadedStatus
    {
        [Description("OK")]
        Ok = 1,
        [Description("NOT_HTTPS")]
        NotHTTPS = 2,
        [Description("FEED_ALREADY_ADDED")]
        FeedAlreadyAdded = 3,
        [Description("BAD_HTTP_CODE")]
        BadHTTPCode = 4,
        [Description("BAD_MIME_TYPE")]
        BadMIMEType = 5,
        [Description("TIMED_OUT")]
        TimedOut = 6,
        [Description("INCORRECT_URL")]
        IncorrectURL = 7,
        [Description("WRONG_REGION")]
        WrongRegion = 8,
    }
}
