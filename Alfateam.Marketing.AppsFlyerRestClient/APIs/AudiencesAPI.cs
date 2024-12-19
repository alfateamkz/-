using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Analytics;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Audiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class AudiencesAPI : AbsAPI
    {
        public AudiencesAPI(AppsFlyerClient client) : base(client)
        {
            AdditionalIdentifiersAPI = new AdditionalIdentifiersAPI(this.Client);
            AudienceExternalAPI = new AudienceExternalAPI(this.Client);
            AudienceImportAPI = new AudienceImportAPI(this.Client);
        }

        public AdditionalIdentifiersAPI AdditionalIdentifiersAPI { get; private set; }
        public AudienceExternalAPI AudienceExternalAPI { get; private set; }
        public AudienceImportAPI AudienceImportAPI { get; private set; }
    }
}
