using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Marketplace;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class MeasurementsAPI : AbsAPI
    {
        public MeasurementsAPI(AppsFlyerClient client) : base(client)
        {
            EngagementsAPI = new EngagementsAPI(this.Client);
            PCConsoleCTVEventsAPI = new PCConsoleCTVEventsAPI(this.Client);
            PreloadC2SMeasurementAPI = new PreloadC2SMeasurementAPI(this.Client);
            PreloadMeasurementAPI = new PreloadMeasurementAPI(this.Client);
            ServerToServerEventsAPI = new ServerToServerEventsAPI(this.Client);
            WebServerToServerAPI = new WebServerToServerAPI(this.Client);
        }

        public EngagementsAPI EngagementsAPI { get; private set; }
        public PCConsoleCTVEventsAPI PCConsoleCTVEventsAPI { get; private set; }
        public PreloadC2SMeasurementAPI PreloadC2SMeasurementAPI { get; private set; }
        public PreloadMeasurementAPI PreloadMeasurementAPI { get; private set; }
        public ServerToServerEventsAPI ServerToServerEventsAPI { get; private set; }
        public WebServerToServerAPI WebServerToServerAPI { get; private set; }
    }
}
