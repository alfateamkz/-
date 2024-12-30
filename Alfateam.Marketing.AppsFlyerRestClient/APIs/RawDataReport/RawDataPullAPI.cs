using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.RawDataPull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.RawDataReport
{
    public class RawDataPullAPI : AbsAPI
    {
        public RawDataPullAPI(AppsFlyerClient client) : base(client)
        {
            AdRevenueRawData = new RawAdRevenueRawDataModule(this.Client);
            Retargeting = new RawRetargetingModule(this.Client);
        }

        public RawAdRevenueRawDataModule AdRevenueRawData { get; private set; }
        public RawRetargetingModule Retargeting { get; private set; }
    }
}
