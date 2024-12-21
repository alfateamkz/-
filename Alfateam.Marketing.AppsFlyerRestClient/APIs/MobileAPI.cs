using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class MobileAPI : AbsAPI
    {
        public MobileAPI(AppsFlyerClient client) : base(client)
        {
            GCDAPIForSDKAttributionTesting = new GCDAPIForSDKAttributionTesting(this.Client);
            TestConsoleAPI = new TestConsoleAPI(this.Client);
        }

        public GCDAPIForSDKAttributionTesting GCDAPIForSDKAttributionTesting { get; set; }
        public TestConsoleAPI TestConsoleAPI { get; set; }
    }
}
