using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.ActiveAudiences
{
    public class GetActiveAudiencesForAccountResponseResult
    {
        [JsonProperty("audience_id")]
        public string AudienceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("updating_user")]
        public string UpdatingUser { get; set; }
    }
}
