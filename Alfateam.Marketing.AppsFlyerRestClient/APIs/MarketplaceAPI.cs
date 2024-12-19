using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Audiences;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Marketplace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class MarketplaceAPI : AbsAPI
    {
        public MarketplaceAPI(AppsFlyerClient client) : base(client)
        {
            PartnerIntegrationSettingsAPI = new PartnerIntegrationSettingsAPI(this.Client);
        }

        public PartnerIntegrationSettingsAPI PartnerIntegrationSettingsAPI { get; private set; }
    }
}
