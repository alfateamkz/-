using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class RestrictionsSettingsDTO : DTOModelAbs<RestrictionsSettings>
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
