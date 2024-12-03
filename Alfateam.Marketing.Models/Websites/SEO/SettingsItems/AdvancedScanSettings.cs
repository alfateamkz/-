using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems
{
    public class AdvancedScanSettings : AbsModel
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
