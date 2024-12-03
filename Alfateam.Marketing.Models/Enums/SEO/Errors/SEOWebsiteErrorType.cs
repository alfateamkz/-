using Alfateam.Marketing.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Enums.SEO.Errors
{
    public enum SEOWebsiteErrorType
    {
        //Критические ошибки
        [SEOErrorSeverityType(SEOErrorSeverity.High)] BrokenPages = 1,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Errors4XX = 2,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Errors5XX = 3,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] InvalidURLLinks = 4,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] PageClones = 5,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] TextClones = 6,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] ContainsLoremIpsum = 7,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] H1Clones = 8,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] NoTitleOrEmpty = 9,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] NoDescriptionOrEmpty = 10,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] BrokenRedirect = 11,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] RedirectsWithInvalidURLLink = 12,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] InfiniteRedirect = 13,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] MaxCountOfRedirects = 14,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] BlockedInRobotsTxtRedirect = 15,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] NotIndexedCanonicalURL = 16,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] CanonicalURLsChain = 17,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] BrokenImages = 18,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] LocalhostLink = 19,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] PageRankHangingNode = 20,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] PagesWithoutInnerLinks = 21,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] InvalidAMP_HTML_Format = 22,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] ContainsFlash = 23,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Hreflang_NoCurrentURLLink = 24,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Hreflang_InvalidLangCodes = 25,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Hreflang_RelativeLinks = 26,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Hreflang_LangCodesDublicates = 27,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Hreflang_NonIndexedURLsLinks = 28,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Hreflang_NoReturnLinks = 29,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] Hreflang_IncorrectReturnLinksLangCode = 30,



        //Средняя критичность
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] MinContentSize = 201,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] RedirectsChain = 202,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] RefreshRedirect = 203,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] PageRankRedirect = 204,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] Redirect_HTTPS_To_HTTP = 205,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] MixedContent = 206,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] Hyperlink_HTTPS_To_HTTP = 207,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] SeveralTitleTags = 208,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] SeveralDescriptionTags = 209,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] SameTitleAndDescriptionTags = 210,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] GetParametersContainQuestionMark = 211,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] URLsWithAnalyticsSystemsMark = 212,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] IndexedAMPPages = 213,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] BlockedInRobotsTxt = 214,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] BlockedInMetaRobots = 215,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] BlockedInXRobotsTag = 216,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] OrthographicErrors = 217,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] GA4_NotIndexedPagesWithTraffic = 218,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] UA_NotIndexedPagesWithTraffic = 219,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] GA4_MaxBounceRate = 220,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] UA_MaxBounceRate = 221,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] GSC_NotIndexedPagesWithIndicators = 222,




        //Низкая критичность
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] NotHTTPSProtocol = 401,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] URLWithIncorrectHyphenUsage = 402,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] URLWithUndesiredSymbols = 403,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] SameTitleAndH1 = 404,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] ShortTitle = 405,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxTitleLength = 406,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] TitleContainsEmojiOrSpecialSymbols = 407,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] ShortDescription = 408,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxDescriptionLength = 409,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] DescriptionContainsEmojiOrSpecialSymbols = 410,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxH1Length = 411,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxHTMLLength = 412,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxContentLength = 413,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] NotCanonicalPages = 414,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] SameCanonicalURLs = 415,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] CanonicalURLContainsOtherHost = 416,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] NofollowInMetaRobots = 417,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] NofollowInXRobotsTag = 418,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] PageRankNoRelations = 419,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxInnerLinksCount = 420,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxOuterLinksCount = 421,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] InnerNofollowLinks = 422,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] OuterNofollowLinks = 423,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] Hreflang_NoAlternateURLs = 424,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] Hreflang_AlternateURLDublicates = 425,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] InvalidBaseTagFormat = 426,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] IndexedURlsWithGetParameters = 427,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] MaxURLLength = 428,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] GA4_IndexedPagesWithoutTraffic = 429,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] UA_IndexedPagesWithoutTraffic = 430,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] GSC_IndexedPagesWithoutWatches = 431,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] GSC_IndexedPagesWithoutClicks = 432,
    }


}
