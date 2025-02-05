using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Websites.SEO.SettingsItems
{
    public class AdvancedScanSettingsDTO : DTOModelAbs<AdvancedScanSettings>
    {
        public bool ScanRobotsTxt { get; set; }
        public bool ScanCanonical { get; set; }
        public bool ScanRefresh { get; set; }
        public bool ScanXRobotsTag { get; set; }
        public bool ScanMetaRobots { get; set; }
        public bool ScanNofollowAttibute { get; set; }



        public bool ScanFromLinkTagHreflang { get; set; }
        public bool ScanFromLinkTagNextPrev { get; set; }
        public bool ScanFromLinkTagAMP_HTML { get; set; }
        public bool ScanFromLinkTagOther { get; set; }




        public bool StopScanningIf429Error { get; set; }
        public bool StopScanningIfConnectionTimeout { get; set; }



        public bool AllowCookies { get; set; }
        public bool ScanPagesWith4XXError { get; set; }
        public bool ScanRelativelyCanonicalURLs { get; set; }
    }
}
