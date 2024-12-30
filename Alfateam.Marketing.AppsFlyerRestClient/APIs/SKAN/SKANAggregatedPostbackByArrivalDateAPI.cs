using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANAggregatedPostbackByArrivalDate.Postbacks;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANConversionStudio.GetSKANSchema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.SKAN
{
    public class SKANAggregatedPostbackByArrivalDateAPI : AbsAPI
    {
        public SKANAggregatedPostbackByArrivalDateAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> GetAggregatedPostbacks(string appId, GetAggregatedPostbacksQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/skadnetworks-postbacks/v3/data/app/{appId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
