using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.CreateAudience
{
    public class CreateNewImportedAudienceResponse
    {
        [JsonProperty("message")]
        public CreateNewImportedAudienceResponseMessage Message { get; set; }
    }
}
