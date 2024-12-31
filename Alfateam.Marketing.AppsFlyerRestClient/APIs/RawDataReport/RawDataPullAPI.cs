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
            NonOrganicInstalls = new RawNonOrganicInstallsModule(this.Client);
            OrganicInstalls = new RawOrganicInstallsModule(this.Client);
            Postbacks = new RawPostbacksModule(this.Client);
            Protect360Fraud = new RawProtect360FraudModule(this.Client);
            Retargeting = new RawRetargetingModule(this.Client);
        }

        public RawAdRevenueRawDataModule AdRevenueRawData { get; private set; }
        public RawNonOrganicInstallsModule NonOrganicInstalls { get; private set; }
        public RawOrganicInstallsModule OrganicInstalls { get; private set; }
        public RawPostbacksModule Postbacks { get; private set; }
        public RawProtect360FraudModule Protect360Fraud { get; private set; }
        public RawRetargetingModule Retargeting { get; private set; }
    }
}
