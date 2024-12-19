using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.ActiveAudiences
{
    public class GetActiveAudiencesForAccountResponse
    {
        [JsonProperty("message")]
        public GetActiveAudiencesForAccountResponseMsg Message { get; set; }
    }
}
