using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems
{
    public class RestrictionsSettings : AbsModel
    {
        public int MaxScanURLsCount { get; set; }
        public int MaxScanDepth { get; set; }
        public int MaxURLsNesting { get; set; }
        public int MaxRedirectsCount { get; set; }




        public int MinTitleLength { get; set; }
        public int MaxTitleLength { get; set; }


        public int MinDescriptionLength { get; set; }
        public int MaxDescriptionLength { get; set; }



        public int MinContentLength { get; set; }
        public int MaxContentLength { get; set; }



        public int MaxH1Length { get; set; }
        public int MaxHTMLLength { get; set; }
        public int MaxUrlLength { get; set; }
        public int MaxServerResponseTime { get; set; }
        public int MaxInnerLinksCount { get; set; }
        public int MaxOuterLinksCount { get; set; }
        public int MaxImageSizeInKBs { get; set; }
        public int MinHTMLandTextRatio { get; set; }
        public int MaxPercentOfFailures { get; set; }
    }
}
