using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Onelink;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.RawDataReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class RawDataReportAPI : AbsAPI
    {
        public RawDataReportAPI(AppsFlyerClient client) : base(client)
        {
            PushAPIConfigurationAPI = new PushAPIConfigurationAPI(this.Client);
            RawDataPullAPI = new RawDataPullAPI(this.Client);
            AggregatePullAPI = new AggregatePullAPI(this.Client);
            MasterAPI = new MasterAPI(this.Client);
            MasterFreshnessAPI = new MasterFreshnessAPI(this.Client);
        }

        public PushAPIConfigurationAPI PushAPIConfigurationAPI { get; private set; }
        public RawDataPullAPI RawDataPullAPI { get; private set; }
        public AggregatePullAPI AggregatePullAPI { get; private set; }
        public MasterAPI MasterAPI { get; private set; }
        public MasterFreshnessAPI MasterFreshnessAPI { get; private set; }
    }
}
