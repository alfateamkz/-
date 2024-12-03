using Alfateam.Marketing.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Enums.SEO.Errors
{
    public enum SEOSitemapErrorType
    {       
        //Критические ошибки
        [SEOErrorSeverityType(SEOErrorSeverity.High)] BrokenSitemap = 1,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] InvalidRootTagSitemap = 2,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] SitemapParsingError = 3,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] InvalidContentType = 4,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] CompressionError = 5,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] NotUTF8Encoding = 6,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] BlockedInRobotsTxtSitemap = 7,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] MaxSitemapFileSize = 8,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] MaxLinksCountInIndexFileSitemap = 9,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] MaxURLsCount = 10,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] NoLinksInSitemap = 11,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] InvalidSitemapURLFormat = 12,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] InvalidURLFormat = 13,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] MaxSitemapLength = 14,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] MaxURLLength = 15,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] EncodedSitemapURL = 16,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] NotEncodedURLInSitemap = 17,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] URLContainsSpecialSymbols = 18,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] SitemapDuplicates = 19,
        [SEOErrorSeverityType(SEOErrorSeverity.High)] LinkToIndexFileSitemap = 20,



        //Средняя критичность
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] RedirectedSitemap = 201,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] IncorrectSitemapPosition = 202,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] IncorrectURLPosition = 203,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] InvalidURLPriority = 204,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] PriorityOutOfRange = 205,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] InvalidURLChangefreq = 206,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] InvalidURLLastmod = 207,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] InvalidSitemapLastmod = 208,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] ServerResponseTimeTooLong = 209,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] NoSitemapIndexInRobotsTxt = 210,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] URLDuplicates = 211,
        [SEOErrorSeverityType(SEOErrorSeverity.Medium)] ContainsByteOrderMark = 212,




        //Низкая критичность
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] EncodedURLs = 401,
        [SEOErrorSeverityType(SEOErrorSeverity.Low)] NoSitemapInRobotsTxt = 402,
    }

}
