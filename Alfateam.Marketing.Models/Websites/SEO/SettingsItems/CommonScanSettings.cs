using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SettingsItems
{
    public class CommonScanSettings : AbsModel
    {
        public int DelayBetweenRequestsInMs { get; set; }
        public int MaxRequestWaitingTimeInMs { get; set; }


        public bool ScanOnlyInPart { get; set; }
        public bool ScanAllSubdomains { get; set; }
        public bool ScanExternalLinks { get; set; }


        public bool CheckJS { get; set; }
        public bool CheckCSS { get; set; }
        public bool CheckImages { get; set; }
        public bool CheckImagesFromSrcsetAttribute { get; set; }
        public bool CheckPDF { get; set; }
        public bool CheckOtherMIMETypes { get; set; }


        public bool EnableMultidomainScanning { get; set; }
    }
}
