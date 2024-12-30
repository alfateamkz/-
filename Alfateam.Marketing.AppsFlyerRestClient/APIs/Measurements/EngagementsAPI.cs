using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Modules.Measurements.Engagements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements
{
    public class EngagementsAPI : AbsAPI
    {
        public EngagementsAPI(AppsFlyerClient client) : base(client)
        {
            ClickEngagement = new MeasurementEngagementsClickModule(this.Client);
            ImpressionEngagement = new MeasurementEngagementsImpressionModule(this.Client);
        }

        public MeasurementEngagementsClickModule ClickEngagement { get; private set; }
        public MeasurementEngagementsImpressionModule ImpressionEngagement { get; private set; }
    }
}
