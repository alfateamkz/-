using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class AnalyticsAPI : AbsAPI
    {
        public AnalyticsAPI(AppsFlyerClient client) : base(client)
        {
            CohortAPI = new CohortAPI(this.Client);
        }

        public CohortAPI CohortAPI { get; private set; }
    }
}
