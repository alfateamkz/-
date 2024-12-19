using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Import
{
    public class ImportANewAudienceResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
