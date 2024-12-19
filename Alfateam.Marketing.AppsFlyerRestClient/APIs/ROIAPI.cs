using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.RawDataReport;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.ROI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class ROIAPI : AbsAPI
    {
        public ROIAPI(AppsFlyerClient client) : base(client)
        {
            TrueRevenueTaxAPI = new TrueRevenueTaxAPI(this.Client);
            AdRevenueAccountIntegrationsAPI = new AdRevenueAccountIntegrationsAPI(this.Client);
            IncostAPI = new IncostAPI(this.Client);
        }

        public TrueRevenueTaxAPI TrueRevenueTaxAPI { get; private set; }
        public AdRevenueAccountIntegrationsAPI AdRevenueAccountIntegrationsAPI { get; private set; }
        public IncostAPI IncostAPI { get; private set; }
    }
}
