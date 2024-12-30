using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Modules.Mobile.TestConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Mobile
{
    public class TestConsoleAPI : AbsAPI
    {
        public TestConsoleAPI(AppsFlyerClient client) : base(client)
        {
            AllowedDevices = new MobileTestConsoleAllowedDevicesModule(this.Client);
            Events = new MobileTestConsoleEventsModule(this.Client);
        }

        public MobileTestConsoleAllowedDevicesModule AllowedDevices { get; private set; }
        public MobileTestConsoleEventsModule Events { get; private set; }
    }
}
