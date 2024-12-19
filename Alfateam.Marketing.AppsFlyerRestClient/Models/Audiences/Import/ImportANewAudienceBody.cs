using Alfateam.Marketing.AppsFlyerRestClient.Enums;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Audiences.Import;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Import
{
    public class ImportANewAudienceBody
    {
        [JsonProperty("import_key")]
        public string ImportKey { get; set; }

        [JsonProperty("platform")]
        public Platform Platform { get; set; }
    }
}
