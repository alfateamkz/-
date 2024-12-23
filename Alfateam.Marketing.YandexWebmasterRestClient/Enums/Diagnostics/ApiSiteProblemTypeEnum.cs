using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Diagnostics
{
    public enum ApiSiteProblemTypeEnum
    {
        //FATAL
        [Description("CONNECT_FAILED")]
        ConnectFailed = 1,
        [Description("DISALLOWED_IN_ROBOTS")]
        DisallowedInRobots = 2,
        [Description("DNS_ERROR")]
        DNSError = 3,
        [Description("MAIN_PAGE_ERROR")]
        MainPageError = 4,
        [Description("THREATS")]
        Threats = 5,
        [Description("TURBO_FEED_BAN")]
        TurboFeedBan = 6,

        //CRITICAL
        [Description("INSIGNIFICANT_CGI_PARAMETER")]
        InsignificantCGIParameter= 101,
        [Description("SLOW_AVG_RESPONSE_TIME")]
        SlowAvgResponseTime = 102,
        [Description("SSL_CERTIFICATE_ERROR")]
        SSLCertificateError = 103,
        [Description("TURBO_HOST_BAN")]
        TurboHostBan = 104,
        [Description("TURBO_RSS_ERROR")]
        TurboRSSError = 105,
        [Description("TURBO_URL_ERRORS")]
        TurboURLErrors = 106,
        [Description("URL_ALERT_4XX")]
        URLAlert4XX = 107,
        [Description("URL_ALERT_5XX")]
        URLAlert5XX = 108,

        //POSSIBLE_PROBLEM
        [Description("DISALLOWED_URLS_ALERT")]
        DisallowedURLsAlert = 201,
        [Description("DOCUMENTS_MISSING_DESCRIPTION")]
        DocumentsMissingDescription = 202,
        [Description("DOCUMENTS_MISSING_TITLE")]
        DocumentsMissingTitle = 203,
        [Description("DUPLICATE_CONTENT_ATTRS")]
        DuplicateContentAttrs = 204,
        [Description("DUPLICATE_PAGES")]
        DuplicatePages = 205,
        [Description("ERROR_IN_ROBOTS_TXT")]
        ErrorINRobotsTXT = 206,
        [Description("ERRORS_IN_SITEMAPS")]
        ErrorsInSitemaps = 207,
        [Description("FAVICON_ERROR")]
        FaviconError = 208,
        [Description("MAIN_MIRROR_IS_NOT_HTTPS")]
        MainMirrorIsNotHTTPS = 209,
        [Description("MAIN_PAGE_REDIRECTS")]
        MainPageRedirects = 210,
        [Description("NO_METRIKA_COUNTER_BINDING")]
        NoMetrikaCounterBinding = 211,
        [Description("NO_METRIKA_COUNTER_CRAWL_ENABLED")]
        NoMetrikaCounterCrawlEnabled = 212,
        [Description("NO_ROBOTS_TXT")]
        NoRobotsTXT = 213,
        [Description("NO_SITEMAPS")]
        NoSitemaps = 214,
        [Description("NO_SITEMAP_MODIFICATIONS")]
        NoSitemapModifications = 215,
        [Description("NON_WORKING_VIDEO")]
        NonWorkingVideo = 216,
        [Description("SOFT_404")]
        Soft404 = 217,
        [Description("TOO_MANY_DOMAINS_ON_SEARCH")]
        TooManyDomainsOnSearch = 218,
        [Description("TURBO_HOST_BAN_INFO")]
        TurboHostBanInfo = 219,
        [Description("TURBO_RSS_WARNING")]
        TurboRSSWarning = 220,
        [Description("VIDEOHOST_OFFER_FAILED")]
        VideohostOfferFailed = 221,
        [Description("VIDEOHOST_OFFER_IS_NEEDED")]
        VideohostOfferIsNeeded = 222,
        [Description("VIDEOHOST_OFFER_NEED_PAPER")]
        VideohostOfferNeedPaper = 223,

        //RECOMMENDATION
        [Description("BIG_FAVICON_ABSENT")]
        BigFaviconAbsent = 301,
        [Description("FAVICON_PROBLEM")]
        FaviconProblem = 302,
        [Description("NO_METRIKA_COUNTER")]
        NoMetrikaCounter = 303,
        [Description("NO_REGIONS")]
        NoRegions = 304,
        [Description("NOT_IN_SPRAV")]
        NotInSprav = 305,
        [Description("NOT_MOBILE_FRIENDLY")]
        NotMobileFriendly = 306,
        [Description("SPRAV_COMPANY_PROFILE_CREATED")]
        SpravCompanyProblemCreated = 307,
        [Description("VYGODA_POSSIBLE_ACTIVATION")]
        VygodaPossibleActivation = 308
    }
}
