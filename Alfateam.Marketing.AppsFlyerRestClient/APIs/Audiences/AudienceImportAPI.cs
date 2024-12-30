using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.AddModify;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Import;
using static System.Collections.Specialized.BitVector32;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Audiences.Import;
using Newtonsoft.Json;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Audiences
{
    public class AudienceImportAPI : AbsAPI
    {
        public AudienceImportAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<ImportANewAudienceResponse> ImportNewAudience(ImportANewAudienceActionType action, ImportANewAudienceBody body)
        {
            string url = this.Client.CombineURL($"/audiences-import-api/v2/{JsonConvert.SerializeObject(action)}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ImportANewAudienceResponse>(url, Method.Post, body);
        }
    }
}
