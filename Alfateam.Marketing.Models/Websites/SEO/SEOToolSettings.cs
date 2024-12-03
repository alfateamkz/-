using Alfateam.Core;
using Alfateam.Marketing.Models.Websites.SEO.SettingsItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Alfateam.Marketing.Models.Websites.SEO
{
    public class SEOToolSettings : AbsModel
    {

        public CommonScanSettings CommonScanSettings { get; set; }
        public AdvancedScanSettings AdvancedScanSettings { get; set; }


        public VirtualRobotsTxt VirtualRobotsTxt { get; set; }
        public List<HTTPHeader> Headers { get; set; } = new List<HTTPHeader>();
        public WebsiteBaseAuthentication WebsiteBaseAuthentication { get; set; }



        public RestrictionsSettings RestrictionsSettings { get; set; }
        public OrthographySettings OrthographySettings { get; set; }
        public URLRules URLRules { get; set; }



        public List<UserAgentSettings> UserAgentsSettings = new List<UserAgentSettings>();



        public bool UseProxies { get; set; }
        public List<Proxy> Proxies = new List<Proxy>();
    }
}
