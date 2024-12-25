using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.UpdateApplication
{
    public class UpdateApplicationBody
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public int Category { get; set; }

        [JsonProperty("time_zone_name")]
        public string TimeZoneName { get; set; }

        [JsonProperty("hide_address")]
        public bool HideAddress { get; set; }

        [JsonProperty("gdpr_agreement_accepted")]
        public bool GDPRAgreementAccepted { get; set; }

        [JsonProperty("bundle_id")]
        public string BundleId { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("use_universal_links")]
        public bool UseUniversalLinks { get; set; }
    }
}
