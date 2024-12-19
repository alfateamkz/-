using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Analytics
{
    public class CohortAPI : AbsAPI
    {
        protected const string BaseURL = AppsFlyerClient.HOST + "cohorts/v1/";
        public CohortAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task CreateCohortReport()
        {

        }
    }
}
