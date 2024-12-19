using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.ROI;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.SKAN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class SKANAPI : AbsAPI
    {
        public SKANAPI(AppsFlyerClient client) : base(client)
        {
            SKANAggregatedPerformanceReportAPI = new SKANAggregatedPerformanceReportAPI(this.Client);
            SKANAggregatedPostbackByArrivalDateAPI = new SKANAggregatedPostbackByArrivalDateAPI(this.Client);
            SKANAggregatedPostbackByArrivalDateAPI = new SKANAggregatedPostbackByArrivalDateAPI(this.Client);
            SKANCVSchemaAPIForAdNetworks = new SKANCVSchemaAPIForAdNetworks(this.Client);
            SKANCVSchemaAPIForAdvertisers = new SKANCVSchemaAPIForAdvertisers(this.Client);
        }

        public SKANAggregatedPerformanceReportAPI SKANAggregatedPerformanceReportAPI { get; private set; }
        public SKANAggregatedPostbackByArrivalDateAPI SKANAggregatedPostbackByArrivalDateAPI { get; private set; }
        public SKANConversionStudioAPI SKANConversionStudioAPI { get; private set; }
        public SKANCVSchemaAPIForAdNetworks SKANCVSchemaAPIForAdNetworks { get; private set; }
        public SKANCVSchemaAPIForAdvertisers SKANCVSchemaAPIForAdvertisers { get; private set; }
    }
}
